using HelloWorlds.Models.Enums;

namespace HelloWorlds.Models
{
    public class City : BaseDbModel
    {
        public string Name { get; set; }

        public virtual CityType Type { get; set; }
    }
}