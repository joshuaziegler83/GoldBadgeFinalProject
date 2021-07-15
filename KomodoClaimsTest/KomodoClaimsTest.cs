using KomodoClaimsDeptRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace KomodoClaimsTest
{
    [TestClass]
    public class KomodoClaimsTest
    {
        private ClaimRepository _repo = new ClaimRepository();

        public DataTable _queue = new DataTable();


        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _queue = new DataTable();
            _queue.Columns.Add("Claim ID", typeof(int));
            _queue.Columns.Add("Type of Claim", typeof(ClaimType));
            _queue.Columns.Add("Description", typeof(string));
            _queue.Columns.Add("Claim Amount", typeof(double));
            _queue.Columns.Add("Date of Incident", typeof(string));
            _queue.Columns.Add("Date of Claim", typeof(string));
            _queue.Columns.Add("Is Valid", typeof(bool));
            _queue.Rows.Add(1, (ClaimType)1, "House Fire", 100, "01/15/1983", "02/14/1983", true);
        }


        [TestMethod]
        public void ShouldInitializeDataTable()
        {
            Arrange();

            int count = _queue.Columns.Count;

            Assert.AreEqual(7, count);
        }

        [TestMethod]
        public void ShouldAddNewClaim()
        {
            Arrange();
            int count = _queue.Rows.Count;

            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ShouldDeleteAClaim()
        {
            Arrange();

            _queue.Rows[0].Delete();
            _queue.AcceptChanges();

            int count = _queue.Rows.Count;

            Assert.AreEqual(count, 0);
        }
    }
}
