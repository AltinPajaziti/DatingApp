using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    
    public class AccountController(DataContext context) : BaseApiController
    {

        [HttpPost("register")]

        public async Task<ActionResult<AppUsser>> Register(RegisterDto User)
        {

            if(await this.UserExists(User.Username))
            {
                return BadRequest("Username is taken");
            }
            using var hmac = new HMACSHA512();
            var user = new AppUsser{
                UserName = User.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(User.Password)),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);

             await context.SaveChangesAsync();

            return Ok(user);    

        }


        [HttpPost("login")]

        public async Task<ActionResult<AppUsser>> Login(LoginDto User)
        {

            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == User.Username);

            if(user == null)
            {
                return Unauthorized("User does not exists");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(User.Password));

            for (int i = 0; i < computedhash.Length; i++)
            {
                if (computedhash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }

            return user;

        }

        private async Task<bool> UserExists(string username)
        {
            var user = await context.Users.Where(x=>x.UserName == username).FirstOrDefaultAsync();

            if(user != null)
            {
                return true;
            }
            return false;   
        }
    }

   
}
