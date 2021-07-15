using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repository
{
    public class Badge
    {
        public Badge(int badgeID, string badgeName, List<string> doorNames)
        {
            BadgeID = badgeID;
            BadgeName = badgeName;
            DoorNames = doorNames;
        }

        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public string BadgeName { get; set; }
    }
}
