using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class World : BaseDbModel
    {
        public string Name { get; set; }
        public WorldEnum WorldType { get; set; } = WorldEnum.Planet;

        // nav
        public ICollection<Country> Countries { get; set; }

        public World() { }

        public World(string name)
        {
            Name = name;
        }
    }
}