using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimPrincipleExtensions
    {
        public static string GetUsername(this  ClaimsPrincipal User)
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            if(username == null) throw new Exception("you cannot get the username");

            return username;
        }



        public static int GetUserId(this ClaimsPrincipal User)
        {
            var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (UserId == null) throw new Exception("you cannot get the username");

            return UserId;
        }
    }
}
