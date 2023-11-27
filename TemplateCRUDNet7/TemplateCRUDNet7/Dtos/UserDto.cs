using System.ComponentModel.DataAnnotations;

namespace TemplateCRUDNet7.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public record class UserRegisterDto([Required][MaxLength(60)] string Email, [Required][MaxLength(60)] string Password, [Required][MaxLength(100)] string Name);
}
