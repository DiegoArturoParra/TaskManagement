using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Helpers;

namespace TemplateCRUDNet7.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<ResponseDto<TokenDto>> Login(LoginDto login);
        Task<ResponseDto<UserDto>> Perfil();
        Task<ResponseDto<Unit>> Register(UserRegisterDto user);
    }
}
