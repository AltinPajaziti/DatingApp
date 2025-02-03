using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("GetAllUsers")]    

        public IActionResult GetAllUsers()
        {
            return Ok("This is the list of users");
        }   
    }
}
