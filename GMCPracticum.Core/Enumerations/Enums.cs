using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  GCMPracticum.Core.Enums
{
    /// <summary>
    /// The different types of menu dishes that can be used in IMealMenuOption object
    /// </summary>
    public enum DishTypes
    {
        None = 0,
        Entree = 1,
        Side = 2,
        Drink = 3,
        Dessert = 4
    }


    /// <summary>
    /// The different types of menus that are available
    /// </summary>
    public enum MenuTypes
    {
        None = 0,
        Morning = 1,
        Night = 2
    }
}
