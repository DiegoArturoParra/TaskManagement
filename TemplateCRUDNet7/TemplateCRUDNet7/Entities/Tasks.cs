using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateCRUDNet7.Entities
{
    [Table("TASKS")]
    public partial class Tasks : SoftDeleteEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        [Required]
        [StringLength(150)]
        public string NameTask { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}