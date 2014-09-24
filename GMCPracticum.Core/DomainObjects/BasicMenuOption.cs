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
    /// 
    /// </summary>
    public class BasicMenuOption : IMenuOption
    {
        private MenuTypes _menuType = MenuTypes.None;
        private DishTypes _dishType = DishTypes.None;
        private string _name = string.Empty;

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

        public MenuTypes MenuType
        {
            get
            {
                return _menuType;
            }
            set
            {
                _menuType = value;
            }
        }

        public bool IsMultipleSelection
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
