using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.MealMenus;
using GCMPracticum.Core.Enums;
using GCMPracticum.Core.Extensions;
using GCMPracticum.Core.Utility;
using GCMPracticum.Core.Exceptions;
using GCMPracticum.Core.DomainObjects;
using System.Text.RegularExpressions;

namespace GCMPracticum.Core.RenderObjects
{

    /// <summary>
    /// A class that represents a BasicMealRender and own the process of converting given meal selection input into valid meal output
    /// </summary>
    public class BasicMealRenderer : IMealRenderer
    {
        #region Fields

        private readonly IDictionary<MenuTypes, IMealMenu> _mealMenus = new Dictionary<MenuTypes,IMealMenu>();
        private string _displayDelimiter = ",";
        private string _inputDelimiter = ",";
        private bool _isCaseSensitive = false;
        private int _minimumDishSelectionsRequired = 1;
        private IDictionary<DishTypes, int> _renderOrder = Constants.GetDefaultMealRenderOrder();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicMealRenderer"/> class.
        /// </summary>
        /// <param name="mealMenus">The meal menus.</param>
        /// <exception cref="GCMPracticum.Core.Exceptions.DuplicateMenuTypeException"></exception>
        public BasicMealRenderer(IEnumerable<IMealMenu> mealMenus)
        {
            if (!mealMenus.Any())
                throw new EmptyMealRenderException(Constants.ERROR_EMPTY_MEAL_RENDERER);

            foreach (var mealMenu in mealMenus)
            {
                //If the collection of meal menus contains more than one menu for the same menu type throw an exception indicating
                //the current mealMenus parameter cannot be used to construct the IMealRenderer class
                if (_mealMenus.ContainsKey(mealMenu.MenuType))
                    throw new DuplicateMenuTypeException(string.Format(Constants.ERROR_DUPLICATE_MEAL_MENU, mealMenu.MenuType));

                _mealMenus.Add(mealMenu.MenuType, mealMenu);
            }
        }

        #endregion

        #region Public Properties
        public string DisplayDelimeter
        {
            get
            {
                return _displayDelimiter;
            }
            set
            {
                _displayDelimiter = value;
            }
        }

        public bool IsCaseSensitive
        {
            get
            {
                return _isCaseSensitive;
            }
            set
            {
                _isCaseSensitive = value;
            }
        }


        public string InputDelimeter
        {
            get
            {
                return _inputDelimiter;
            }
            set
            {
                _inputDelimiter = value;
            }
        }

        public IDictionary<DishTypes, int> RenderOrder
        {
            get
            {
                return _renderOrder;
            }
            set
            {
                _renderOrder = value;
            }
        }

        public int MinimumDishSelectionsRequired
        {
            get
            {
                return _minimumDishSelectionsRequired;
            }
            set
            {
                _minimumDishSelectionsRequired = value;
            }
        }

        #endregion

        #region Public Methods
        public string RenderMeals(string mealInput)
        {
            var mealInputCollection = mealInput.Split(new string[1] { InputDelimeter }, StringSplitOptions.None);
            return ProcessMealInput(mealInputCollection);
        }

        #endregion

        #region Private Heliper Methods
        private MenuTypes ParseMenuType(string menuTypeValue)
        {
            var currentMenuType = MenuTypes.None;
            //If the menuType isn't in the form of word it is invalid
            if (!Regex.IsMatch(menuTypeValue, @"^[a-zA-Z]+$"))
                return currentMenuType;
            //Parse out the menu type, decide if it is cases sensitive based on the IsCaseSensitive
            Enum.TryParse(menuTypeValue, !IsCaseSensitive, out currentMenuType);
            return currentMenuType;
        }

        private IEnumerable<DishTypes> ParseDishTypes(IEnumerable<string> selectionData)
        {
            var dishTypes = new List<DishTypes>();

            foreach (var selection in selectionData)
            {
                var currentDishType = DishTypes.None;
                //Add the enum to the collection regardless if the TryParse is true it's not the job of the MealRenderer to determine if they are valid
                Enum.TryParse(selection, out currentDishType);
                dishTypes.Add(currentDishType);
            }

            return dishTypes;
        }

        private string ProcessMealInput(IEnumerable<string> mealSelectionData)
        {
            //If no data is supplied simply send back an error
            //If there is not more than one data element to get at least a menu type and one dish type simply error out
            if (!mealSelectionData.Any() || mealSelectionData.Count() == 1)
                return Constants.ERROR_DEFAULT;

            //Parse for a MenuType to use to retrieve the correct IMealMenu class
            //If the MenuType is invalid simply send back an error because there will be no way to pick the right menu without it
            var currentMenuType = ParseMenuType(mealSelectionData.First().Trim());
            if (currentMenuType == MenuTypes.None || !_mealMenus.ContainsKey(currentMenuType))
                return Constants.ERROR_DEFAULT;

            var mealMenu = _mealMenus[currentMenuType];
            //Parse the list of dish type selections using data after the menu type has been collected
            var dishSelectionInput = new List<string>();
            var dataIndex = 0;
            foreach (var data in mealSelectionData)
            {
                if (dataIndex > 0)
                    dishSelectionInput.Add(data);
                dataIndex++;
            }

            //Check to see if the number of dish selections is at least the miniumum required
            //If not simply send back an error
            var dishCount = dishSelectionInput.Count();
            if (dishCount < MinimumDishSelectionsRequired)
                return Constants.ERROR_DEFAULT;

            //Parse the dish types and the get a list of selected meals from the menu in order to generate output
            var dishTypes = ParseDishTypes(dishSelectionInput);
            var mealOrders = mealMenu.GetSelectedMealOrders(dishTypes);

            return GenerateMealList(mealOrders);
        }

        private string GenerateMealList(IEnumerable<IMealOrder> mealOrders)
        {
            var mealListValues = new List<IMealRenderResult>();
            var hasError = false;

            //Group the meal orders returned from the menu in order to figure out which orders need to show up multiple times i.e potato(x2)
            var mealOrderGroup = from mealOrder in mealOrders
                                  group mealOrder by mealOrder.MenuOption.Name.ToLower() into mealGroup
                                  select mealGroup;

            //The formats for the output single items "steak", multiple items "steak(x2)"
            var singleDishFormat = "{0}";
            var multipleDishFormat = "{0}(x{1})";
            //Loop through the groups and determine which format needs to be used
            //Evaluate the group to identify if a IMealOrder in the group contains any invalid orders because it will cause the evaluation to end 
            foreach (var mealGroup in mealOrderGroup)
            {
                var groupCount = mealGroup.Count(); //Number of items to pick format for successful multiple selection
                var groupName = mealGroup.Key; //The name of the menu item
                hasError = mealGroup.Any(m => !m.IsMealAllowed); //If any of the IMealOrder items has is not allowed consider it an error group
                var mealName = string.Empty;
                if (!hasError)
                {
                    //The non error path is simple, if the group has more that one use the format that matches that, if not use the single format
                    if (groupCount > 1)
                        mealName = string.Format(multipleDishFormat, groupName, groupCount);
                    else
                        mealName = string.Format(singleDishFormat, groupName);

                    mealListValues.Add(new BasicMealRenderResult() { Text = mealName, DishType = mealGroup.First().MenuOption.DishType });
                }
                else
                {   //In the error path order the items in the group in the order they were originally recieved then continue to populate the list until an invalid order is reached
                    //Once the first invalid is reached exit the loop for the group
                    foreach (var meal in mealGroup.OrderBy(m => m.OrderIndex))
                    {
                        mealName = meal.IsMealAllowed ? groupName : Constants.ERROR_DEFAULT;
                        mealListValues.Add(new BasicMealRenderResult() { Text = mealName, DishType = meal.MenuOption.DishType });
                        if (!meal.IsMealAllowed)
                            break;
                    }
                }
                //Check to see if the entire process needs to stop because an error was found
                if (hasError)
                    break;
            }

            //Select the text values of the IMealRenderResult objects then use Join to generate results using the delimiter
            //Now apply the sort for the render order
            return string.Join(DisplayDelimeter, mealListValues.OrderBy(m => RenderOrder[m.DishType]).Select(t => t.Text));
        }

        #endregion
    }
}
