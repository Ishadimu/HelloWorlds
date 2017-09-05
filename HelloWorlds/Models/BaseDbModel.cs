using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloWorlds.Models
{
    public class BaseDbModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime InsertedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? VoidTime { get; set; }

        public virtual ApplicationUser InsertedBy { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
    }
}