using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StateType Type { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}