using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
 

    public class UsersController : BaseApiController
    {


        private readonly DataContext _context;


        public UsersController(DataContext context)
        {
            _context = context;


        }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<AppUsser>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);


        }
    }

}
