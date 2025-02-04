using Microsoft.AspNetCore.Identity;

namespace API.Dtos
{
    public class LoginDto
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
