using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SharedLib.Auth
{
    public class IdentitySharedService : IIdentitySharedService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentitySharedService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public string GetUserMail => _contextAccessor.HttpContext.User.FindFirst("email")?.Value;
    }
}
