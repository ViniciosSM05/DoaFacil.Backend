using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DoaFacil.Backend.Infra.Authentication.AuthProviders.User
{
    public class UserAuthProvider(IHttpContextAccessor httpContextAccessor) : IUserAuthProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public bool IsAuthenticated => UserClaims?.Identity?.IsAuthenticated is true;

        public string UserEmail => IsAuthenticated
            ? UserClaims.FindFirstValue(ClaimTypes.Email)
            : null;

        public Guid UserId => IsAuthenticated
            ? Guid.Parse(UserClaims.FindFirstValue(ClaimTypes.NameIdentifier))
            : Guid.Empty;

        public string UserName => IsAuthenticated
            ? UserClaims.FindFirstValue(ClaimTypes.Name)
            : null;

        public string UserRole => IsAuthenticated
            ? UserClaims.FindFirstValue(ClaimTypes.Role)
            : null;

        private ClaimsPrincipal UserClaims => _httpContextAccessor?.HttpContext?.User;
    }
}
