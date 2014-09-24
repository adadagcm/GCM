using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Enums;

namespace GCMPracticum.Core.Interfaces
{
    public interface IMealRenderer
    {
        /// <summary>
        /// Renders the meals.
        /// </summary>
        /// <param name="mealInput">The meal input.</param>
        /// <returns></returns>
        string RenderMeals(string mealInput);

        /// <summary>
        /// Gets or sets the render order.
        /// </summary>
        /// <value>
        /// The render order.
        /// </value>
        IDictionary<DishTypes, int> RenderOrder { get; set; }

        /// <summary>
        /// Gets or sets the display delimeter.
        /// </summary>
        /// <value>
        /// The display delimeter.
        /// </value>
        string DisplayDelimeter { get; set; }

        /// <summary>
        /// Gets or sets the input delimeter.
        /// </summary>
        /// <value>
        /// The input delimeter.
        /// </value>
        string InputDelimeter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is case sensitive.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is case sensitive; otherwise, <c>false</c>.
        /// </value>
        bool IsCaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets the minimum dish selections required.
        /// </summary>
        /// <value>
        /// The minimum dish selections required.
        /// </value>
        int MinimumDishSelectionsRequired { get; set; }



    }
}
