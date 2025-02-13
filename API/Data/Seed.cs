using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
    public static class Seed
    {
        public static async Task SeedUSers(DataContext context)
        {
           if(await context.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var user = JsonSerializer.Deserialize<List<AppUsser>>(userData, option);

            foreach(var item in user)
            {
                using var hmac = new HMACSHA512();

                item.UserName = item.UserName.ToLower();
                item.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("pa$$w0rd"));
                item.PasswordSalt = hmac.Key;

                context.Users.Add(item);
            }


            await context.SaveChangesAsync();   
        }
    }
}
