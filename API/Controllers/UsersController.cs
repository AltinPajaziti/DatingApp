using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {


        private readonly IUserRepository _repository;


        public UsersController(IUserRepository repository)
        {
            _repository = repository;


        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _repository.GetMembersAsync();


            return Ok(users);
        }

        [HttpGet("{username}")]  // /api/users/2
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _repository.GetMemberAsync(username);

            if (user == null) return NotFound();


            return user;
        }
    }

}
