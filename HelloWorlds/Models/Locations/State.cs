using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class State : BaseDbModel
    {
        public string Name { get; set; }

        public virtual StateType Type { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}