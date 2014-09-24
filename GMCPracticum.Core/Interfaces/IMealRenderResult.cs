using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Enums;
using GCMPracticum.Core.Interfaces;

namespace GCMPracticum.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMealRenderResult
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the type of the dish.
        /// </summary>
        /// <value>
        /// The type of the dish.
        /// </value>
        DishTypes DishType { get; set; }
        
    }
}
