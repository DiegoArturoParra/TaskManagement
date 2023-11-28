using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Repositories.Interfaces;

namespace TemplateCRUDNet7.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync(LoginDto login)
        {
            var response = await _accountRepository.Login(login);
            return StatusCode((int)response.StatusCode, response);
        }


        [Authorize]
        [HttpGet("info-person")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PerfilAsync()
        {
            var response = await _accountRepository.Perfil();
            return StatusCode((int)response.StatusCode, response);
        }


        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto register)
        {
            var response = await _accountRepository.Register(register);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
