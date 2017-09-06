using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models.Locations
{
    public class City : BaseDbModel
    {
        public string Name { get; set; }
        public CityEnum CityType { get; set; } = CityEnum.City;
        public int StateId { get; set; }

        public virtual State State { get; set; }

        public City () { }

        public City(string name, State state)
        {
            Name = name;
            StateId = state.Id;
        }
    }
}