using Komodo_Insurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsuranceTest
{
    [TestClass]
    public class KomodoInsuranceTest
    {
        private BadgeRepo _repo = new BadgeRepo();

        public List<Badge> _badges = new List<Badge>();

        [TestMethod]
        public void ShouldGetBadgeByID()
        {
            List<string> doorNames = new List<string>();
            Badge expectedBadge = new Badge(1, "Bob", doorNames);
            _repo.AddNewBadge(expectedBadge);
            var actualBadge = _repo.GetBadgeByBadgeID(1);
            Assert.AreEqual(expectedBadge, actualBadge);
        }
        
        [TestMethod]
        public void ShouldAddItemToMenu()
        {
            List<string> doorNames = new List<string>();
            Badge newBadge = new Badge(1, "Bob", doorNames);

            bool passed = _repo.AddNewBadge(newBadge);

            Assert.IsTrue(passed);
        }

        [TestMethod]
        public void ShouldDeleteDoorsFromBadge()
        {
            List<string> doors = new List<string>();
            doors.Add("A1");
            Badge newBadge = new Badge(1, "Bob", doors);
            _repo.AddNewBadge(newBadge);
            bool passed = _repo.DeleteAllDoorsFromBadge(newBadge);

            Assert.IsTrue(passed);
        }
    }
}
