using System;
using HelloWorlds.Models.Locations;

namespace HelloWorlds.Models.Travels
{
    public class FutureVisit : BaseDbModel
    {
        public DateTime VisitTime { get; set; }

        // nav
        public City City { get; set; }
        public ApplicationUser User { get; set; }
    }
}