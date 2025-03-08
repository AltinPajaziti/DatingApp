using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUsser User { get; set; } = null!;
        public AppRole Role { get; set; } = null!;
    }
}
