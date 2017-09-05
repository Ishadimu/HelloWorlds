using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class World : BaseDbModel
    {
        public string Name { get; set; }

        public virtual WorldType Type { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}