using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class World : BaseDbModel
    {
        public string Name { get; set; }
        public virtual WorldEnum WorldType { get; set; } = WorldEnum.Planet;
        public virtual ICollection<Country> Countries { get; set; }

        public World() { }

        public World(string name)
        {
            Name = name;
        }
    }
}