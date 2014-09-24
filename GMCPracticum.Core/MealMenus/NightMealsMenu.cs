using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.BaseClass;
using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.Enums;

namespace GCMPracticum.Core.MealMenus
{
    public class NightMealsMenu : MealMenuBase
    {

        public NightMealsMenu(IEnumerable<IMenuOption> mealOptions): base(MenuTypes.Night, mealOptions)
        {

        }
        
    }
}
