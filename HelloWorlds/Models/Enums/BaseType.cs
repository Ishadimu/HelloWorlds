using System.ComponentModel.DataAnnotations;

namespace HelloWorlds.Models.Enums
{
    public class BaseType : BaseDbModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}