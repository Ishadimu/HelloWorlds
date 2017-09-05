using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class World
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WorldType Type { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}