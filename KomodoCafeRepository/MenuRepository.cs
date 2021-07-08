using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinalProject
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuItems = new List<Menu>();
        
        public bool AddItemToMenu(Menu menuItem)
        {
            var count = _menuItems.Count;
            _menuItems.Add(menuItem);
            if (count < _menuItems.Count)
            {
                return true;
            }
            return false;
        }
        
        public bool DeleteItemFromMenu(Menu menuItem)
        {
            if (_menuItems.Contains(menuItem))
            {
                return _menuItems.Remove(menuItem);
            }
            return false;
        }

        public List<Menu> GetAllMenuItems()
        {
            return _menuItems;
        }

        public Menu GetMenuItemByNumber(int mealNum)
        {
            foreach(var item in _menuItems)
            {
                if (mealNum == item.MealNum)
                {
                    return item;
                }
                continue;
            }
            return null;
        }
    }
    
}
