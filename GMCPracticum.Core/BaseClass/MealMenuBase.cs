using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.Enums;
using GCMPracticum.Core.Extensions;
using GCMPracticum.Core.Utility;
using GCMPracticum.Core.DomainObjects;

namespace GCMPracticum.Core.BaseClass
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MealMenuBase : IMealMenu
    {
        private readonly IDictionary<DishTypes, IMenuOption> _menuOptions = new Dictionary<DishTypes, IMenuOption>();
        private readonly MenuTypes _menuType = MenuTypes.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="MealMenuBase"/> class.
        /// </summary>
        /// <param name="menuType">Type of the menu.</param>
        /// <param name="availableMeals">The available meals.</param>
        /// <exception cref="System.Exception">
        /// Invalid Menu Type
        /// or
        /// </exception>
        protected MealMenuBase(MenuTypes menuType, IEnumerable<IMenuOption> availableMeals)
        {
            //Do not attempt to populate a list of meals if a valid menu type is not supplied
            if (menuType != MenuTypes.None)
                _menuType = menuType;
            else
                throw new Exception("Invalid Menu Type");

            //Add the list of available meals 
            //Ensure that no meal type shows up twice and that the meal options match the current menu type
            //Also ensure no meals with invalid data are included
            foreach(var meal in availableMeals)
            {
                var validMealData = meal.HasValidData();
                //If a valid meal for a particular dish type has already been added throw an exception indicating this fact instead of allowing the menu to be constructed
                if (validMealData && meal.MenuType == _menuType && _menuOptions.ContainsKey(meal.DishType))
                    throw new Exception(string.Format(Constants.ERROR_DUPLICATE_DISH_TYPE, meal.DishType));

                if (validMealData && meal.MenuType == _menuType && !_menuOptions.ContainsKey(meal.DishType))
                    _menuOptions.Add(meal.DishType, meal);
            }
        }

        public MenuTypes MenuType
        {
            get { return _menuType; }
        }

        public virtual IEnumerable<IMealOrder> GetSelectedMealOrders(IEnumerable<DishTypes> dishSelections)
        {
            var mealResults = new List<IMealOrder>();

            var orderIndex = 0;
            foreach(var selection in dishSelections)
            {
                //Retrieve the IMealOption that matches the current dish selection if it exists on the menu
                IMenuOption selectedMeal = _menuOptions.ContainsKey(selection) ? _menuOptions[selection] : new BasicMenuOption();
                var validMeal = selectedMeal.HasValidData();
                //Check to see if the current selection is allowed to be added to the menu based on the MultipleAllowed property and if it already exists in the results collectio
                var isMealAllowed = validMeal && (selectedMeal.IsMultipleSelection || !mealResults.Any(m => m.MenuOption != null && m.MenuOption.DishType == selection));
                
                //Add a MealOrder object with an index for for the selection and a reference to the menu option
                mealResults.Add(new BasicMealOrder()
                {
                    IsMealAllowed = isMealAllowed,
                    MenuOption = selectedMeal,
                    OrderIndex = orderIndex,
                });

                orderIndex++;
            }

            return mealResults;
        }
    }
}
