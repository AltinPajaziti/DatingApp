﻿using API.Dtos;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository(DataContext context , IMapper mapper) : IUserRepository
    {
        public async Task<MemberDto?> GetMemberAsync(string username)
        {
            return await context.Users.Where(x=>x.UserName == username)
                .ProjectTo<MemberDto>(mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userparams)
        {
            var query = context.Users
                .ProjectTo<MemberDto>(mapper.ConfigurationProvider) 
                .AsQueryable();

            return await PagedList<MemberDto>.CreateAsync(query, userparams.PageNumber, userparams.PageSize);
        }

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
