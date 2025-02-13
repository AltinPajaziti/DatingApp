using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {


        private readonly IUserRepository _repository;


        public UsersController(IUserRepository repository)
        {
            _repository = repository;


        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<AppUsser>> GetAllUsers()
        {
            var users = await _repository.GetUsersAsync();

            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);


        }
    }

}
