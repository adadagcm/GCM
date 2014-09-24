using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Enums;

namespace  GCMPracticum.Core.Interfaces
{
    /// <summary>
    /// An Interface used for types that are to be considered menus
    /// </summary>
    public interface IMealMenu
    {
        /// <summary>
        /// Gets the type of the menu. Example Morning or Night
        /// </summary>
        /// <value>
        /// An enumeration value that indicates what the MenuType is.
        /// </value>
        MenuTypes MenuType { get; }
        /// <summary>
        /// Gets the selected meal orders. A collection of DishTypes is used to generate a list of IMealOrder objects based on the rules of the IMealMenu
        /// </summary>
        /// <param name="dishSelections">The dish selections as a collection of DishTypes Enumeration values.</param>
        /// <returns></returns>
        IEnumerable<IMealOrder> GetSelectedMealOrders(IEnumerable<DishTypes> dishSelections);
    }
}
