using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Context;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Entities;
using TemplateCRUDNet7.Helpers;
using TemplateCRUDNet7.Repositories.Interfaces;
using TemplateCRUDNet7.Services;

namespace TemplateCRUDNet7.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TemplateContext _context;
        private readonly ITokenService _tokenService;
        private readonly IClaimsHelper _claimsHelper;

        public AccountRepository(TemplateContext context, ITokenService tokenService, IClaimsHelper claimsHelper)
        {
            _context = context;
            _tokenService = tokenService;
            _claimsHelper = claimsHelper;
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

        public async Task<ResponseDto<UserDto>> Perfil()
        {
            var userId = _claimsHelper.GetUserId();
            var user = await _context.TableUsers.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                return Responses.ResponseNotFound<UserDto>("No se encontro el usuario.");
            return Responses.ResponseSuccess(new UserDto { Email = user.Email, Name = user.Name });
        }

        public async Task<ResponseDto<Unit>> Register(UserRegisterDto user)
        {
            user.Email = user.Email.Trim();
            var isExistUser = await _context.TableUsers.AnyAsync(x => x.Email.Equals(user.Email));
            if (isExistUser)
                return Responses.ResponseNotFound<Unit>("Ya existe una persona con el email.");

            await _context.TableUsers.AddAsync(new User
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
            });
            await _context.SaveChangesAsync();
            return Responses.ResponseCreated("Se ha registrado satisfactoriamente.");
        }
    }
}
