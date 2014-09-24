using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Core.Interfaces;
using GCMPracticum.Core.Enums;

namespace GCMPracticum.Core.DomainObjects
{
    /// <summary>
    /// A class  that represents a basic IMealRenderResult
    /// </summary>
    public class BasicMealRenderResult : IMealRenderResult
    {
        private string _text = string.Empty;
        private DishTypes _dishType = DishTypes.None;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public DishTypes DishType
        {
            get
            {
                return _dishType;
            }
            set
            {
                _dishType = value;
            }
        }
    }
}
