using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimPrincipleExtensions
    {
        public static string GetUsername(this  ClaimsPrincipal User)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(username == null) throw new Exception("you cannot get the username");

            return username;
        }
    }
}
