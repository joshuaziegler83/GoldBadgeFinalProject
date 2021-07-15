using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDeptRepo
{
    public class ClaimRepository
    {
        private readonly DataTable _queue = new DataTable();

        public void InitializeDataTable()
        {
            _queue.Columns.Add("Claim ID", typeof(int));
            _queue.Columns.Add("Type of Claim", typeof(ClaimType));
            _queue.Columns.Add("Description", typeof(string));
            _queue.Columns.Add("Claim Amount", typeof(double));
            _queue.Columns.Add("Date of Incident", typeof(string));
            _queue.Columns.Add("Date of Claim", typeof(string));
            _queue.Columns.Add("Is Valid", typeof(bool));
        }

        public void AddClaimToQueue(Claim claim)
        {
            _queue.Rows.Add(claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
        }

        public void DeleteClaimFromQueue()
        {
            _queue.Rows[0].Delete();
            _queue.AcceptChanges();
        }

        public void DisplayAllClaims()
        {
            //Console.WriteLine("----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|");
            Console.WriteLine("{0,-10}{1,-12}{2,-20}{3,-13}{4,-17}{5,-15}{6,-10}", "Claim ID", "Claim Type", "Description", "Claim Amount", "Date of Incident", "Date of Claim", "Is Valid");
            foreach (DataRow dr in _queue.Rows)
            {
                Console.WriteLine("{0,-10}{1,-12}{2,-20}{3,-13:C2}{4,-17}{5,-15}{6,-10}", dr[0], (ClaimType)dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
            }
            Console.ReadKey();
        }

        public static string GetDateFromDateTime(DateTime datevalue)
        {
            return datevalue.ToShortDateString();
        }
    }
}

