using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateCRUDNet7.Entities
{
    [Table("USER")]
    public partial class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(60)]
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(60)]
        public string Password { get; set; }
    }
}
