using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public async Task<AppUsser?> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public Task<AppUsser?> GetUserByUsernameAsync(string username)
        {
            return context.Users.Include(u => u.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUsser>> GetUsersAsync()
        {
            return await context.Users.Include(u=>u.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
           return await context.SaveChangesAsync() > 0;
        }

        public void Update(AppUsser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
