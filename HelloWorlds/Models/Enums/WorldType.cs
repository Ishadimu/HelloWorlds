using HelloWorlds.Extensions;

namespace HelloWorlds.Models.Enums
{
    public enum WorldEnum
    {
        World = 0,
        Planet = 1
    }

    public class WorldType : BaseType
    {
        public static implicit operator WorldType(WorldEnum @enum) => new WorldType(@enum);

        public static implicit operator WorldEnum(WorldType type) => (WorldEnum)type.Id;

        private WorldType(WorldEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        protected WorldType()
        {
        }
    }
}