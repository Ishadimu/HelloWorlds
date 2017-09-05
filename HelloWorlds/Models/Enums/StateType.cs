using HelloWorlds.Extensions;

namespace HelloWorlds.Models.Enums
{
    public enum StateEnum
    {
        State = 0
    }

    public class StateType : BaseType
    {
        public static implicit operator StateType(StateEnum @enum) => new StateType(@enum);

        public static implicit operator StateEnum(StateType type) => (StateEnum)type.Id;

        private StateType(StateEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            Description = @enum.GetEnumDescription();
        }

        protected StateType()
        {
        }
    }
}