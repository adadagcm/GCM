
using NUnit.Framework;
using System.Collections.Generic;
using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.Utility;
using GCMPracticum.Core.MealMenus;
using GCMPracticum.Core.Enums;
using GCMPracticum.Core.RenderObjects;

namespace GCMPracticum.Tests
{
    [TestFixture]
    public class MealRendererTests
    {
        [Test]
        public void MorningMenuSimpleSelectionTest()
        {
            var expectedOutput = "eggs,toast,coffee";
            var input = "morning,1,2,3";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void MorningNoDessertTest()
        {
            var expectedOutput = "eggs,toast,coffee,error";
            var input = "morning,1,2,3,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
            //Assert.AreEqual(expectedOutput, resultOutput, string.Format("Incorrect output for Morning menu output, Expected \"{0}\", Actual \"{1}\"",expectedOutput, resultOutput));
        }

        [Test]
        public void NightMenuSimpleSelectionTest()
        {
            var expectedOutput = "steak,potato,wine,cake";
            var input = "night,1,2,3,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
            //Assert.AreEqual(expectedOutput, resultOutput, string.Format("Incorrect output for Morning menu output, Expected \"{0}\", Actual \"{1}\"",expectedOutput, resultOutput));
        }

        [Test]
        public void MorningMealsSortOrderTest()
        {
            var expectedOutput = "eggs,toast,coffee";
            var input = "morning,2,1,3";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void MorningMealsMultipleCoffeeTest()
        {
            var expectedOutput = "eggs,toast,coffee(x3)";
            var input = "morning,1,2,3,3,3";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void NightMealsMultiplePotatoTest()
        {
            var expectedOutput = "steak,potato(x2),cake";
            var input = "night,1,2,2,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }
        [Test]
        public void NightMealsMultipleSteakTest()
        {
            var expectedOutput = "steak,error";
            var input = "night,1,1,2,3,5";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }
        
        [Test]
        public void IsCaseSensitiveMealTest()
        {
            var expectedOutput = "error";
            var input = "NIghT,1,1,2,3,5";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.IsCaseSensitive = true;

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void NotCaseSensitiveMenuTypeTest()
        {
            var expectedOutput = "steak,error";
            var input = "NIghT,1,1,2,3,5";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.IsCaseSensitive = false;

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void InvalidDishFormatAsTextTest()
        {
            var expectedOutput = "error";
            var input = "night,entree,side,drink,dessert";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void InvalidDishFormatNoCommasBetweenMenuAndDishTypesTest()
        {
            var expectedOutput = "error";
            var input = "morning1234";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void InvalidDishFormatNoCommasBetweenDishTypesTest()
        {
            var expectedOutput = "error";
            var input = "morning,1234";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void InvalidDishFormatDifferentDelimiterBetweenDishTypesTest()
        {
            var expectedOutput = "error";
            var input = "morning;1;2;3;4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.InputDelimeter = ",";

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void InvalidDishFormatCombinationDelimiterBetweenDishTypesTest()
        {
            var expectedOutput = "eggs,error";
            var input = "morning,1,2;3;4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.InputDelimeter = ",";

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }


        [Test]
        public void MultipleMenuTypeTest()
        {
            var expectedOutput = "error";
            var input = "night,morning,1,2,3,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }


        [Test]
        public void DishAsMenuTypeTest()
        {
            var expectedOutput = "steak,potato(x2),error";
            var input = "night,1,2,2,morning,4";


            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void RenderOrderTest()
        {
            var expectedOutput = "potato(x2),steak,error";
            var input = "night,1,2,2,morning,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());
            mealMenus.Add(Constants.GetDefaultMorningMenu());
            var renderOrder = new Dictionary<DishTypes, int>() 
            {
                { DishTypes.Side, 0 },
                { DishTypes.Entree, 1 },
                { DishTypes.Dessert, 3 },
                { DishTypes.Drink, 2 },
                { DishTypes.None, 4 },
            };
            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.RenderOrder = renderOrder;
   
            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void CorrectOutputDelimiterTest()
        {
            var expectedOutput = "eggs<br>toast<br>coffee(x3)";
            var input = "morning,1,2,3,3,3";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultMorningMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.DisplayDelimeter = "<br>";

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);

        }

        [Test]
        [ExpectedException("GCMPracticum.Core.Exceptions.DuplicateMenuTypeException")]
        public void DuplicateMenuNotSupportedTest()
        {
            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());
            mealMenus.Add(Constants.GetDefaultNightMenu());

            //There should be an exception thrown when attempting to construct the MealRender because duplicates are not allowed
            var mealRenderer = new BasicMealRenderer(mealMenus);
        }

        [Test]
        [ExpectedException("GCMPracticum.Core.Exceptions.EmptyMealRenderException")]
        public void MealRenderNoMenusTest()
        {
            var mealMenus = new List<IMealMenu>();

            //There should be an exception thrown when attempting to construct the MealRender because BasicMealRenderer should not initialize without at least one menu
            var mealRenderer = new BasicMealRenderer(mealMenus);
        }

        [Test]
        public void MinimumDishTotalSingleSelectedTest()
        {
            var expectedOutput = "error";
            var input = "morning,";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.MinimumDishSelectionsRequired = 1;

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void MinimumDishTotalMultipleSelectedTest()
        {
            var expectedOutput = "steak,potato";
            var input = "night,1,2";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.MinimumDishSelectionsRequired = 2;

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void MinimumDishTotalMultipleNotSelectedTest()
        {
            var expectedOutput = "error";
            var input = "night,1";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.MinimumDishSelectionsRequired = 2;

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void NightMenuWineMultipleNotSupportedTest()
        {
            var expectedOutput = "steak,potato,wine,error";
            var input = "night,1,2,3,3,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);
            mealRenderer.MinimumDishSelectionsRequired = 2;

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }

        [Test]
        public void AllNumbersInputNotSupportedTest()
        {
            var expectedOutput = "error";
            var input = "1,2,3,3,3,3,4";

            var mealMenus = new List<IMealMenu>();
            mealMenus.Add(Constants.GetDefaultNightMenu());

            var mealRenderer = new BasicMealRenderer(mealMenus);

            var resultOutput = mealRenderer.RenderMeals(input);

            Assert.AreEqual(expectedOutput, resultOutput);
        }
    }
}
