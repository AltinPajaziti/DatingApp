using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    
    public class AccountController(DataContext context , ITokenService tokenService, IMapper mapper) : BaseApiController
    {

        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto User)
        {

            if (await this.UserExists(User.Username))
            {
                return BadRequest("Username is taken");
            }
            using var hmac = new HMACSHA512();

            var user = mapper.Map<AppUsser>(User);

            user.UserName = User.Username.ToLower();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(User.Password));

            user.PasswordSalt = hmac.Key;


            context.Users.Add(user);

            await context.SaveChangesAsync();


            return new UserDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender


            };





        }


        [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto User)
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

            var token = tokenService.CreateToken(user);

            return Ok(new UserDto
            {
                Username = user.UserName,
                Token = token,
                KnownAs = user.KnownAs,
                PhotoUrl = user.Photos.FirstOrDefault(x => x.Ismain)?.Url,
                Gender = user.Gender
            });





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
