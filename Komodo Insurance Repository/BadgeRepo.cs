using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_Repository
{
    public class BadgeRepo
    {
        private readonly List<Badge> _badges = new List<Badge>();

        public bool AddNewBadge(Badge badge)
        {
            var count = _badges.Count;
            _badges.Add(badge);
            if (count < _badges.Count)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAllDoorsFromBadge(Badge badge)
        {
            if (_badges.Contains(badge))
            {
                badge.DoorNames.Clear();
                return badge.DoorNames.Count == 0;
            }
            else
            {
                return false;
            }
        }

        public List<Badge> GetAllBadges()
        {
            return _badges;
        }

        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (var badge in _badges)
            {
                if (badgeID == badge.BadgeID)
                {
                    return badge;
                }
                continue;
            }
            return null;
        }
    }
}