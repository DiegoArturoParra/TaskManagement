using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TemplateCRUDNet7.Helpers
{
    public class ClaimsHelper : IClaimsHelper
    {
        private readonly ILogger<ClaimsHelper> _logger;
        private readonly IHttpContextAccessor _httpContext;
        public ClaimsHelper(ILogger<ClaimsHelper> logger, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;

        }
        public Guid GetUserId()
        {
            Guid usuarioId = Guid.Empty;
            try
            {
                var claimsIdentity = (ClaimsIdentity)_httpContext.HttpContext.User.Identity;
                if (claimsIdentity != null)
                {
                    List<Claim> claims = claimsIdentity.Claims.ToList();
                    var claim = claims.Where(p => p.Type == JwtRegisteredClaimNames.Sid).FirstOrDefault();
                    string userId = claim.Value;
                    usuarioId = claim == null ? Guid.Empty : Guid.Parse(claim.Value);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return usuarioId;
        }
    }

    public interface IClaimsHelper
    {
        Guid GetUserId();
    }
}
