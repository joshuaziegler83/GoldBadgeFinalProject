using GoldBadgeFinalProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoTest
{
    [TestClass]
    public class KomodoTest
    {
        private readonly MenuRepository _repo = new MenuRepository();

        [TestMethod]
        public void ShouldAddItemToMenu()
        {
            Menu item = new Menu(0, "hot dog", "it's a hotdog", new List<string> { "hotdog" }, 0.00);

            bool passed = _repo.AddItemToMenu(item);

            Assert.IsTrue(passed);
        }
        
        [TestMethod]
        public void ShouldDeleteItemFromMenu()
        {
            Menu item = new Menu(0, "hot dog", "it's a hotdog", new List<string> { "hotdog" }, 0.00);

            _repo.AddItemToMenu(item);

            bool passed = _repo.DeleteItemFromMenu(item);

            Assert.IsTrue(passed);
        }
        
        [TestMethod]
        public void ShouldReturnListOfMenuItems()
        {
            var actual =_repo.GetAllMenuItems();
            
            List<Menu> menuItems = new List<Menu>();

            CollectionAssert.AreEqual(menuItems, actual);
        }
        
        [TestMethod]
        public void ShouldReturnAMenuItemByNumber()
        {
            Menu item = new Menu(0, "hot dog", "it's a hotdog", new List<string> { "hotdog" }, 0.00);

            _repo.AddItemToMenu(item);

            var menuItem =_repo.GetMenuItemByNumber(0);

            Assert.AreEqual(item, menuItem);
        }
    }
}
