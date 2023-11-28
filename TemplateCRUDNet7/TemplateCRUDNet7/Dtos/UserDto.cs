using System.ComponentModel.DataAnnotations;

namespace TemplateCRUDNet7.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        [Required]
        [MaxLength(60)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }

}
