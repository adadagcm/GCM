using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.Enums;

namespace GCMPracticum.Core.Extensions
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Determines whether [the specified menu option] has enough data populated to be a valid selection
        /// </summary>
        /// <param name="mealOption">The meal option.</param>
        /// <returns></returns>
        public static bool HasValidData(this IMenuOption menuOption)
        {
            return (!string.IsNullOrWhiteSpace(menuOption.Name) && menuOption.MenuType != MenuTypes.None && menuOption.DishType != DishTypes.None);
        }
    }
}
