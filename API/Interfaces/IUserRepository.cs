using API.Dtos;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUsser user);

        Task<bool> SaveAllAsync(); 

        Task<IEnumerable<AppUsser>> GetUsersAsync();    

        Task<AppUsser?> GetUserByIdAsync(int id);

        Task<AppUsser?> GetUserByUsernameAsync(string username);


        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userparams);

        Task<MemberDto?> GetMemberAsync(string username);

    }
}
