using GCMPracticum.Core.Enums;
using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCMPracticum.Core.MealMenus;

namespace GCMPracticum.Core.Utility
{
    public static class Constants
    {

        public const string ERROR_DUPLICATE_MEAL_MENU = "Unable to construct IMealRenderer type with duplicate menus for the {0} type";
        public const string ERROR_DUPLICATE_DISH_TYPE = "Unable to construct IMealMenu type with duplicate dish type for the {0} type";
        public const string ERROR_EMPTY_MEAL_RENDERER = "Unable to construct IMealRenderer type with no IMealMenu objects present";
        public const string CONSOLE_RENDER_INPUT_TEXT = "Please enter your meals selection. Enter close to exit";

        public const string ERROR_DEFAULT = "error";
        public static IEnumerable<IMenuOption> GetDefaultMorningMeals()
        {
            return new List<IMenuOption>()
            {
               new BasicMenuOption(){ DishType = DishTypes.Entree, MenuType = MenuTypes.Morning, Name = "eggs", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Side, MenuType = MenuTypes.Morning, Name = "Toast", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Drink, MenuType = MenuTypes.Morning, Name = "coffee", IsMultipleSelection = true }
            };
        }

        public static IEnumerable<IMenuOption> GetDefaultNightMeals()
        {
            return new List<IMenuOption>()
            {
               new BasicMenuOption(){ DishType = DishTypes.Entree, MenuType = MenuTypes.Night, Name = "steak", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Side, MenuType = MenuTypes.Night, Name = "potato", IsMultipleSelection = true},
               new BasicMenuOption(){ DishType = DishTypes.Drink, MenuType = MenuTypes.Night, Name = "wine", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Dessert, MenuType = MenuTypes.Night, Name = "cake", IsMultipleSelection = false},
            };
        }

        public static IMealMenu GetDefaultMorningMenu()
        {
            return new MorningMealMenu(GetDefaultMorningMeals());
        }

        public static IMealMenu GetDefaultNightMenu()
        {
            return new NightMealsMenu(GetDefaultNightMeals());
        }

        public static IDictionary<DishTypes,int> GetDefaultMealRenderOrder()
        {
            return new Dictionary<DishTypes, int>() 
            {
                { DishTypes.Entree, 0 },
                { DishTypes.Side, 1 },
                { DishTypes.Drink, 2 },
                { DishTypes.Dessert, 3 },
                { DishTypes.None, 4 },
            };
        }
    }
}
