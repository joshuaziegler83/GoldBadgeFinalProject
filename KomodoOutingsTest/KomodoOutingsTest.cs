using KomodoOutingsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;

namespace KomodoOutingsTest
{
    [TestClass]
    public class KomodoOutingsTest
    {
        private OutingRepo _repo = new OutingRepo();
        public DataTable _outings = new DataTable();

        [TestInitialize]
        public void Arrange()
        {
            _outings.Columns.Add("Event Type", typeof(EventType));
            _outings.Columns.Add("Number of People", typeof(int));
            _outings.Columns.Add("Date", typeof(string));
            _outings.Columns.Add("Cost Per Person", typeof(double));
            _outings.Columns.Add("Total Cost of Event", typeof(double));
        }

        [TestMethod]
        public void ShouldInitializeDatatable()
        {
            _repo.InitializeDataTable();

            int count = _outings.Columns.Count;

            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void ShouldAddNewOuting()
        {
            _repo.InitializeDataTable();
            _outings.Rows.Add(1, 10, "01/15/1983", 100, 1000);

            int count = _outings.Rows.Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ShouldPerformCalculations()
        {
            _repo.InitializeDataTable();
            Outing outing1 = new Outing((EventType)1, 10, "01/15/1983", 100, 1000);
            Outing outing2 = new Outing((EventType)1, 10, "01/15/1983", 1000, 10000);
            Outing outing3 = new Outing((EventType)2, 10, "01/15/1983", 100, 1000);
            Outing outing4 = new Outing((EventType)2, 10, "01/15/1983", 200, 2000);
            Outing outing5 = new Outing((EventType)3, 10, "01/15/1983", 100, 1000);
            Outing outing6 = new Outing((EventType)3, 10, "01/15/1983", 500, 5000);
            Outing outing7 = new Outing((EventType)4, 10, "01/15/1983", 100, 1000);
            Outing outing8 = new Outing((EventType)4, 10, "01/15/1983", 600, 6000);
            _repo.AddOutingToOutings(outing1);
            _repo.AddOutingToOutings(outing2);
            _repo.AddOutingToOutings(outing3);
            _repo.AddOutingToOutings(outing4);
            _repo.AddOutingToOutings(outing5);
            _repo.AddOutingToOutings(outing6);
            _repo.AddOutingToOutings(outing7);
            _repo.AddOutingToOutings(outing8);
         
            Dictionary<string,double> calcs = _repo.EventCalculations();

            Dictionary<string, double> expectedCalcs = new Dictionary<string,double>();
            expectedCalcs.Add("Golf Total", 11000);
            expectedCalcs.Add("Bowling Total",3000);
            expectedCalcs.Add("Amusement Park Total", 6000);
            expectedCalcs.Add("Concert Total", 7000);
            expectedCalcs.Add("Total", 27000);

            CollectionAssert.AreEqual(calcs, expectedCalcs);
        }
    }
}
