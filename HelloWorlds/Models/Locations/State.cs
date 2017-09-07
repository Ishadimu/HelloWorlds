using System.Collections.Generic;
using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class State : BaseDbModel
    {
        public string Name { get; set; }
        public StateEnum StateType { get; set; } = StateEnum.State;
        public int CountryId { get; set; }

        // nav
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }

        public State() { }

        public State(string name, Country country)
        {
            Name = name;
            CountryId = country.Id;
        }
    }
}