using System.Security.Claims;

namespace clean_architecture_demo_v3_api.SharedServices
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public AuthenticatedUser(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext.User.FindFirstValue("uid");
        }

        public string UserId { get; set; }
    }
}
