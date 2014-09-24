using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace  GCMPracticum.Core.Interfaces
{
    public interface IMealOrder
    {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is meal allowed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is meal allowed; otherwise, <c>false</c>.
        /// </value>
        bool IsMealAllowed { get; set; }

        /// <summary>
        /// Gets or sets the menu option that corresponds to the this IMealOrder.
        /// </summary>
        /// <value>
        /// The menu option.
        /// </value>
        IMenuOption MenuOption { get; set; }

        /// <summary>
        /// Gets or sets the order in which the IMealOrder was generated
        /// </summary>
        /// <value>
        /// The index of the order.
        /// </value>
        int OrderIndex { get; set; }

    }
}
