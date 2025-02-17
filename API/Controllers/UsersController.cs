using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {


        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;


        public UsersController(IUserRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

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



        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (username == null) return BadRequest("No username found in token");

            var user = await _repository.GetUserByUsernameAsync(username);

            if (user == null) return BadRequest("Could not find user");

            _mapper.Map(memberUpdateDto, user);

            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update the user");
        }
    }

}
