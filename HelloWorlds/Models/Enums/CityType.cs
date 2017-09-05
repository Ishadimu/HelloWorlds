using HelloWorlds.Extensions;

namespace HelloWorlds.Models.Enums
{
    public enum CityEnum
    {
        City = 0,
        Village = 1
    }

    public class CityType : BaseType
    {
        public static implicit operator CityType(CityEnum @enum) => new CityType(@enum);

        public static implicit operator CityEnum(CityType type) => (CityEnum)type.Id;

        private CityType(CityEnum @enum)
        {
            Id = (int) @enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        protected CityType()
        {
        }
    }
}