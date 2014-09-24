using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Interfaces;

namespace GCMPracticum.Core.DomainObjects
{
    /// <summary>
    /// A class that represents a IMealOrder object as the most basic type
    /// </summary>
    public class BasicMealOrder : IMealOrder
    {

        public IMenuOption MenuOption
        {
            get;
            set;
        }

        public int OrderIndex
        {
            get;
            set;
        }

        public bool IsMealAllowed
        {
            get;
            set;
        }
    }
}
