using TemplateCRUDNet7.Dtos;

namespace TemplateCRUDNet7.Services
{
    public interface ITokenService
    {
        string CreateToken(UserDto user);
    }
}