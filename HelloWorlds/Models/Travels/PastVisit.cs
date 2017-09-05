using System;

namespace HelloWorlds.Models.Travels
{
    public class PastVisit : BaseDbModel
    {
        public DateTime VisitTime { get; set; }

        public virtual City City { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}