using System;
using HelloWorlds.Models.Locations;

namespace HelloWorlds.Models.Travels
{
    public class FutureVisit : BaseDbModel
    {
        public DateTime VisitTime { get; set; }

        public virtual City City { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}