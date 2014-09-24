using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GCMPracticum.Interfaces;


namespace GCMPracticum.BaseClass
{
    /// <summary>
    /// 
    /// </summary>
    public class MealRenderBase : IMealRenderer
    {
        public virtual string RenderMeals(IEnumerable<string> mealSelectionData)
        {
            throw new NotImplementedException();
        }

        public virtual Dictionary<Enums.DishTypes, int> RenderOrder
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        IDictionary<Enums.DishTypes, int> IMealRenderer.RenderOrder
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string DisplayDelimeter
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public bool IsCaseSensitive
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
