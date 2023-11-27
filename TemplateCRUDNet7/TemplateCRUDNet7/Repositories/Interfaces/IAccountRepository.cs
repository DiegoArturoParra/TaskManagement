using TemplateCRUDNet7.Dtos;

namespace TemplateCRUDNet7.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<ResponseDto<TokenDto>> Login(LoginDto login);
        Task<ResponseDto<UserDto>> Register(UserRegisterDto user);
    }
}
