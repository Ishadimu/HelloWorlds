using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CountryType Type { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}