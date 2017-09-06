using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorlds.Models.Enums
{
    public class BaseType : BaseDbModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}