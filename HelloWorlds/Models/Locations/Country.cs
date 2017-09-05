using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class Country : BaseDbModel
    {
        public string Name { get; set; }

        public virtual CountryType Type { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}