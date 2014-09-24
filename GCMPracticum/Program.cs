using System;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GCMPracticum.Core.Interfaces;
    using GCMPracticum.Core.Utility;
    using Microsoft.Practices.Unity;
    using GCMPracticum.Core.RenderObjects;

    namespace GCMPracticum
    {
        class Program
        {
            static IUnityContainer _iocContainer;
            static IMealRenderer _mealRenderer;
            static void Main(string[] args)
            {
                RegisterTypes();
            
                RequestMealInput();
            }

            static void RequestMealInput()
            {
                Console.WriteLine(Constants.CONSOLE_RENDER_INPUT_TEXT);

                var enteredInput = Console.ReadLine();
                var mealRenderer = CurrentMealRenderer;
                if (enteredInput.ToLower() == "close")
                    Environment.Exit(0);
                var mealResults = mealRenderer.RenderMeals(enteredInput);
                Console.WriteLine(mealResults);
                RequestMealInput();
            }

            static void RegisterTypes()
            {
                _iocContainer = new UnityContainer();
                var mealMenus = new List<IMealMenu>(){ Constants.GetDefaultNightMenu(), Constants.GetDefaultMorningMenu() };
                _iocContainer.RegisterType<IMealRenderer, BasicMealRenderer>(new InjectionConstructor(
                    mealMenus));
            }

            static IMealRenderer CurrentMealRenderer
            {
                get
                {
                    return _mealRenderer ?? _iocContainer.Resolve<IMealRenderer>();
                }
            }
    }
}
