using KomodoOutingsRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutings
{
    public class ProgramUI
    {
        private readonly OutingRepo _repo = new OutingRepo();
        bool isProgramRunning = true;
        public void Run()
        {
            _repo.InitializeDataTable();
            while (isProgramRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Outings. Please choose a number.\n" +
                                    "1) Add an Outing\n" +
                                    "2) View Calculations\n" +
                                    "3) View the Outings\n" +
                                    "4) Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateOuting();
                        break;
                    case "2":
                        ViewCalculations();
                        break;
                    case "3":
                        ViewOutings();
                        break;
                    case "4":
                        isProgramRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option. Press any key to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewCalculations()
        {
            Console.Clear();
            Dictionary<string, double> calculations = _repo.EventCalculations();
            //Console.WriteLine("----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|");
            Console.WriteLine("{0,-13}{1,-16}{2,-23}{3,-16}{4,-15}", "Golf Total", "Bowling Total", "Amusement Park Total", "Concert Total", "Total");
            Console.WriteLine("{0,-13:C2}{1,-16:C2}{2,-23:C2}{3,-16:C2}{4,-15:C2}", calculations["Golf Total"], calculations["Bowling Total"], calculations["Amusement Park Total"], calculations["Concert Total"], calculations["Total"]);
            Console.ReadKey();
        }

        private void CreateOuting()
        {
            Outing outing = new Outing();
            Console.Clear();
            Console.WriteLine("What is the Event Type?  Golf is 1, Bowling is 2, Amusement Park is 3, Concert is 4");
            int eventTypeInt = int.Parse(Console.ReadLine());
            outing.TypeOfEvent = (EventType)eventTypeInt;

            Console.WriteLine("How many people attended? ");
            outing.NumberOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine("When did the event happen? Please use MM/DD/YYYY format ");
            outing.EventDate = Console.ReadLine();

            Console.WriteLine("What is the total cost of the event? ");
            outing.CostOfEvent = double.Parse(Console.ReadLine());

            outing.CostPerPerson = outing.CostOfEvent / outing.NumberOfPeople;
            
            _repo.AddOutingToOutings(outing);
        }

        public void ViewOutings()
        {
            Console.Clear();
            //Console.WriteLine("----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|----|");
            Console.WriteLine("{0,-13}{1,-19}{2,-13}{3,-18}{4,-12}", "Event Type", "Number of People", "Date", "Cost Per Person", "Total Cost");
            foreach (DataRow dr in _repo.GetAllOutings().Rows)
            {
                Console.WriteLine("{0,-13}{1,-19}{2,-13}{3,-18:C2}{4,-12:C2}", (EventType)dr[0], dr[1], dr[2], dr[3], dr[4]);
            }
            Console.ReadKey();
        }
    }
}
