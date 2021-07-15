using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingsRepo
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Outing
    {
        public Outing()
        {
        }

        public Outing(EventType typeOfEvent, int numberOfPeople, string eventDate, double costPerPerson, double costOfEvent)
        {
            TypeOfEvent = typeOfEvent;
            NumberOfPeople = numberOfPeople;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }

        public EventType TypeOfEvent { get; set; }
        public int NumberOfPeople { get; set; }
        public string EventDate { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEvent { get; set; }
    }
}