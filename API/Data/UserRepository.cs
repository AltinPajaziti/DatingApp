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

        public async Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
        {
            var query = context.Users.AsQueryable();

            query = query.Where(u => u.UserName != userParams.CurrentUsername);
            query = query.Where(u => u.Gender == userParams.Gender);

            var minDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-userParams.MaxAge - 1));
            var maxDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-userParams.MinAge));

            query = query.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);

            query = userParams.OrderBy switch
            {
                "created" => query.OrderByDescending(u => u.Created),
                _ => query.OrderByDescending(u => u.LastActive)
            };

            return await PagedList<MemberDto>.CreateAsync(query.AsNoTracking()
                .ProjectTo<MemberDto>(mapper.ConfigurationProvider),
                    userParams.PageNumber, userParams.PageSize);
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
