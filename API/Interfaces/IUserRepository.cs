using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUsser user);

        Task<bool> SaveAllAsync(); 

        Task<IEnumerable<AppUsser>> GetUsersAsync();    

        Task<AppUsser?> GetUserByIdAsync(int id);

        Task<AppUsser?> GetUserByUsernameAsync(string username);


        Task<IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto?> GetMemberAsync(string username);

    }
}
