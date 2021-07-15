using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsRepo
{
    public class OutingRepo
    {
        private readonly DataTable _outings = new DataTable();

        public void InitializeDataTable()
        {
            _outings.Columns.Add("Event Type", typeof(EventType));
            _outings.Columns.Add("Number of People", typeof(int));
            _outings.Columns.Add("Date", typeof(string));
            _outings.Columns.Add("Cost Per Person", typeof(double));
            _outings.Columns.Add("Total Cost of Event", typeof(double));
        }

        public void AddOutingToOutings(Outing outing)
        {
            _outings.Rows.Add(outing.TypeOfEvent, outing.NumberOfPeople, outing.EventDate, outing.CostPerPerson, outing.CostOfEvent);
        }

        public Dictionary<string, double> EventCalculations()
        {
            double golfTotal = 0;
            double bowlingTotal = 0;
            double amusementTotal = 0;
            double concertTotal = 0;

            foreach (DataRow dr in _outings.Rows)
            {
                switch (((EventType)dr[0]))
                {
                    case EventType.Golf:
                        golfTotal += (double)dr[4];
                        break;
                    case EventType.Bowling:
                        bowlingTotal += (double)dr[4];
                        break;
                    case EventType.AmusementPark:
                        amusementTotal += (double)dr[4];
                        break;
                    case EventType.Concert:
                        concertTotal += (double)dr[4];
                        break;
                    default:
                        break;
                }
            }
            double total = golfTotal + bowlingTotal + amusementTotal + concertTotal;

            Dictionary<string, double> calcs = new Dictionary<string, double>();

            calcs.Add("Golf Total", golfTotal);
            calcs.Add("Bowling Total", bowlingTotal);
            calcs.Add("Amusement Park Total", amusementTotal);
            calcs.Add("Concert Total", concertTotal);
            calcs.Add("Total", total);
            
            return calcs;
        }

        public DataTable GetAllOutings()
        {
            return _outings;
        }

    }
}

