using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Context;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Helpers;
using TemplateCRUDNet7.Repositories.Interfaces;
using TemplateCRUDNet7.Services;

namespace TemplateCRUDNet7.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TemplateContext _context;
        private readonly ITokenService _tokenService;
        public AccountRepository(TemplateContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<ResponseDto<TokenDto>> Login(LoginDto login)
        {
            login.Email = login.Email.Trim();
            var user = await _context.TableUsers.FirstOrDefaultAsync(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password));
            if (user == null)
                return Responses.ResponseUnAuthorized<TokenDto>("Email y/o contraseña incorrecta.");

            var token = _tokenService.CreateToken(new UserDto { Email = user.Email, UserId = user.Id, Name = user.Name });

            return Responses.ResponseSuccess(new TokenDto { Token = token, Name = user.Name });
        }

        public async Task<ResponseDto<UserDto>> Register(UserRegisterDto user)
        {
            throw new NotImplementedException();
        }
    }
}
