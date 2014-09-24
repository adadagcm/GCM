using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.Utility;
using GCMPracticum.Core.MealMenus;
using GCMPracticum.Core.Enums;
using GCMPracticum.Core.DomainObjects;

namespace GCMPracticum.Tests
{
    [TestFixture]
    public class MealMenuTests
    {
        [Test]
        public void MorningMealMenuCorrectOptionsTypeTest()
        {
            //Set up a morning menu with a combination of morning and night menu options
            var morningMenuOptions = new List<IMenuOption>()
            {
               new BasicMenuOption(){ DishType = DishTypes.Entree, MenuType = MenuTypes.Morning, Name = "eggs", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Side, MenuType = MenuTypes.Morning, Name = "Toast", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Drink, MenuType = MenuTypes.Night, Name = "wine", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Dessert, MenuType = MenuTypes.Night, Name = "cake", IsMultipleSelection = false},
            };
            var morningMenu = new MorningMealMenu(morningMenuOptions);

            //When attempting to retrieve IMealOrder objects based on DishTypes only the 2 morning options should come back
            var selectedDishes = new List<DishTypes>()
            {
                DishTypes.Entree,
                DishTypes.Side,
                DishTypes.Drink,
                DishTypes.Dessert
            };

            var mealOrderResult = morningMenu.GetSelectedMealOrders(selectedDishes);
            var expectedValidMealCount = 2;
            var actualMealCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.Morning && (m.MenuOption.DishType == DishTypes.Entree || m.MenuOption.DishType == DishTypes.Side));
            var expectedErrorMealCount = 2;
            var actualMealErrorCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.None);

            Assert.AreEqual(expectedValidMealCount, actualMealCount);
            Assert.AreEqual(expectedErrorMealCount, actualMealErrorCount);

        }
        [Test]
        public void NightMealMenuCorrectOptionsTypeTest()
        {
            //Set up a menu with a combination of morning and night menu options
            var menuOptions = new List<IMenuOption>()
            {
               new BasicMenuOption(){ DishType = DishTypes.Entree, MenuType = MenuTypes.Morning, Name = "eggs", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Side, MenuType = MenuTypes.Morning, Name = "Toast", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Drink, MenuType = MenuTypes.Night, Name = "wine", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Dessert, MenuType = MenuTypes.Night, Name = "cake", IsMultipleSelection = false},
            };
            var nightMenu = new NightMealsMenu(menuOptions);

            //When attempting to retrieve IMealOrder objects based on DishTypes only the 2 morning options should come back
            var selectedDishes = new List<DishTypes>()
            {
                DishTypes.Entree,
                DishTypes.Side,
                DishTypes.Drink,
                DishTypes.Dessert
            };

            var mealOrderResult = nightMenu.GetSelectedMealOrders(selectedDishes);
            var expectedValidMealCount = 2;
            var actualMealCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.Night && (m.MenuOption.DishType == DishTypes.Drink || m.MenuOption.DishType == DishTypes.Dessert));
            var expectedErrorMealCount = 2;
            var actualMealErrorCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.None);

            Assert.AreEqual(expectedValidMealCount, actualMealCount);
            Assert.AreEqual(expectedErrorMealCount, actualMealErrorCount);
        }

        [Test]
        public void MorningMenuOptionsValidDataTest()
        {
            //Set up a menu with a combination valid menu items and invalid menu items
            //Blank name, incorrect DishType, Incorrect MenuType will all be tested
            //Only the 
            var menuOptions = new List<IMenuOption>()
            {
               new BasicMenuOption(){ DishType = DishTypes.None, MenuType = MenuTypes.Morning, Name = "eggs", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Side, MenuType = MenuTypes.Morning, Name = "              ", IsMultipleSelection = true},
               new BasicMenuOption(){ DishType = DishTypes.Drink, MenuType = MenuTypes.None, Name = "coffee", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Dessert, MenuType = MenuTypes.Morning, Name = "muffin", IsMultipleSelection = true},
            };
            var morningMenu = new MorningMealMenu(menuOptions);

            //When attempting to retrieve IMealOrder objects based on DishTypes only the 2 morning options should come back
            //The ones for dessert should be the only ones supported because it was specified to support multiple selections
            var selectedDishes = new List<DishTypes>()
            {
                DishTypes.Entree,
                DishTypes.Side,
                DishTypes.Drink,
                DishTypes.Dessert,
                DishTypes.Dessert
            };

            var mealOrderResult = morningMenu.GetSelectedMealOrders(selectedDishes);
            var expectedValidMealCount = 2;
            var actualMealCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.Morning);
            var expectedDesertCount = 2;
            var expectedErrorMealCount = 3;
            var actualMealErrorCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.None);
            var actualDesertCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.Morning && m.MenuOption.DishType == DishTypes.Dessert);


            Assert.AreEqual(expectedValidMealCount, actualMealCount);
            Assert.AreEqual(expectedErrorMealCount, actualMealErrorCount);
            Assert.AreEqual(expectedDesertCount, actualDesertCount);
        }

        [Test]
        public void NightMenuOptionsValidDataTest()
        {
            //Set up a menu with a combination valid menu items and invalid menu items
            //Blank name, incorrect DishType, Incorrect MenuType will all be tested
            //Only the 
            var menuOptions = new List<IMenuOption>()
            {
               new BasicMenuOption(){ DishType = DishTypes.None, MenuType = MenuTypes.Night, Name = "steak", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Side, MenuType = MenuTypes.Night, Name = "              ", IsMultipleSelection = true},
               new BasicMenuOption(){ DishType = DishTypes.Drink, MenuType = MenuTypes.None, Name = "wine", IsMultipleSelection = false},
               new BasicMenuOption(){ DishType = DishTypes.Dessert, MenuType = MenuTypes.Night, Name = "cake", IsMultipleSelection = true},
            };
            var nightMenu = new NightMealsMenu(menuOptions);

            //When attempting to retrieve IMealOrder objects based on DishTypes only the 2 night options should come back
            //The ones for dessert should be the only ones supported because it was specified to support multiple selections and has the correct data for menutype name and dishtype
            var selectedDishes = new List<DishTypes>()
            {
                DishTypes.Entree,
                DishTypes.Side,
                DishTypes.Drink,
                DishTypes.Dessert,
                DishTypes.Dessert
            };

            var mealOrderResult = nightMenu.GetSelectedMealOrders(selectedDishes);
            var expectedValidMealCount = 2;
            var actualMealCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.Night);
            var expectedErrorMealCount = 3;
            var actualMealErrorCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.None);
            var expectedDesertCount = 2;
            var actualDesertCount = mealOrderResult.Count(m => m.MenuOption.MenuType == MenuTypes.Night && m.MenuOption.DishType == DishTypes.Dessert);

            Assert.AreEqual(expectedValidMealCount, actualMealCount);
            Assert.AreEqual(expectedErrorMealCount, actualMealErrorCount);
            Assert.AreEqual(expectedDesertCount, actualDesertCount);
        }
    }
}
