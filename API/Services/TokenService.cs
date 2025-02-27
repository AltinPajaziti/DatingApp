using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        public string CreateToken(AppUsser user)
        {
            var token = config["TokenKey"] ?? throw new Exception("cannot acces token key on appsettings");

            if(token.Length < 64)
            {
                throw new Exception("Your token key needs to be longer");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token));


            var clasims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Name, user.UserName)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var tokendestributer = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clasims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHendeler = new JwtSecurityTokenHandler();
            var thetoken = tokenHendeler.CreateToken(tokendestributer);

            return tokenHendeler.WriteToken(thetoken);



        }

        }
    }

