using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
    public static class Seed
    {
        public static async Task SeedUsers(UserManager<AppUsser> usermanager, RoleManager<AppRole> roleManager)
        {
            if (await usermanager.Users.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var users = JsonSerializer.Deserialize<List<AppUsser>>(userData, options);

            if (users == null) return;

            var roles = new List<AppRole>
        {
            new() {Name = "Member"},
            new() {Name = "Admin"},
            new() {Name = "Moderator"},
        };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName!.ToLower();
                await usermanager.CreateAsync(user, "Pa$$w0rd");
                await usermanager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUsser
            {
                UserName = "admin",
                KnownAs = "Admin",
                Gender = "",
                City = "",
                Country = ""
            };

            await usermanager.CreateAsync(admin, "Pa$$w0rd");
            await usermanager.AddToRolesAsync(admin, ["Admin", "Moderator"]);

        }
    }
}
