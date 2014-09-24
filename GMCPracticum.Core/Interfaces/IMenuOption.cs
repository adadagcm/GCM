using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Enums;

namespace GCMPracticum.Core.Interfaces
{
    public interface IMenuOption
    {
        /// <summary>
        /// Gets or sets the type of the dish.
        /// </summary>
        /// <value>
        /// The type of the dish.
        /// </value>
        DishTypes DishType { get; set; }

        /// <summary>
        /// Gets or sets the type of the menu.
        /// </summary>
        /// <value>
        /// The type of the menu.
        /// </value>
        MenuTypes MenuType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a menu option that supports multiple selection.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is multiple selection; otherwise, <c>false</c>.
        /// </value>
        bool IsMultipleSelection { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }


    }
}
