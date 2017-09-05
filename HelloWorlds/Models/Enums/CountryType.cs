using HelloWorlds.Extensions;

namespace HelloWorlds.Models.Enums
{
    public enum CountryEnum
    {
        Country = 0,
        Kingdom = 1
    }

    public class CountryType : BaseType
    {
        public static implicit operator CountryType(CountryEnum @enum) => new CountryType(@enum);

        public static implicit operator CountryEnum(CountryType type) => (CountryEnum)type.Id;

        private CountryType(CountryEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        protected CountryType()
        {
        }
    }
}