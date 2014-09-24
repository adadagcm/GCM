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
    /// <summary>
    /// 
    /// </summary>
    public class MorningMealMenu : MealMenuBase
    {
        public MorningMealMenu(IEnumerable<IMenuOption> mealOptions): base(MenuTypes.Morning, mealOptions)
        {

        }
        
    }
}
