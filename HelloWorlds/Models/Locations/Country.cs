using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class Country : BaseDbModel
    {
        public string Name { get; set; }
        public CountryEnum CountryType { get; set; }= CountryEnum.Country;
        public int WorldId { get; set; }

        public virtual World World { get; set; }
        public virtual ICollection<State> States { get; set; }

        public Country() { }

        public Country(string name, World world)
        {
            Name = name;
            WorldId = world.Id;
        }
    }
}