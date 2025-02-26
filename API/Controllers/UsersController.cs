using API.Data;
using API.Dtos;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    //[Authorize]
    public class UsersController : BaseApiController
    {


        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPhotoServices _photoServices;


        public UsersController(IUserRepository repository , IMapper mapper, IPhotoServices photoServices)
        {
            _repository = repository;
            _mapper = mapper;
            _photoServices = photoServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery]UserParams userparams)
        {

            userparams.CurrentUsername = User.GetUsername();

            var users = await _repository.GetMembersAsync(userparams);

         
             Response.AddPaginationHeader(users);


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

            var user = await _repository.GetUserByUsernameAsync(User.GetUsername());

            if (user == null) return BadRequest("Could not find user");

            _mapper.Map(memberUpdateDto, user);

            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update the user");
        }


        [HttpPost("add-photo")]

        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            var username = await _repository.GetUserByUsernameAsync(User.GetUsername());

            if(username == null) return BadRequest("cannot update user");
            

            var result = await _photoServices.AddPhotoAsync(file);

            if(result.Error != null) return BadRequest(result.Error.Message);


            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if (username.Photos.Count == 0) photo.Ismain = true;


            username.Photos.Add(photo);


            if(await _repository.SaveAllAsync())
            {
                return CreatedAtAction(nameof(GetUser),
                new { username = username.UserName }, _mapper.Map<PhotoDto>(photo));
            }

            return BadRequest("there was a problem adding the photo");

        }


        [HttpPut("set-main-photo/{photoId:int}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await _repository.GetUserByUsernameAsync(User.GetUsername());

            if (user == null) return BadRequest("Could not find user");

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null || photo.Ismain) return BadRequest("Cannot use this as main photo");

            var currentMain = user.Photos.FirstOrDefault(x => x.Ismain);
            if (currentMain != null) currentMain.Ismain = false;
            photo.Ismain = true;

            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Problem setting main photo");
        }

        [HttpDelete("delete-photo/{photoId:int}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await _repository.GetUserByUsernameAsync(User.GetUsername());

            if (user == null) return BadRequest("User not found");

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null || photo.Ismain) return BadRequest("This photo cannot be deleted");

            if (photo.PublicId != null)
            {
                var result = await _photoServices.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            user.Photos.Remove(photo);

            if (await _repository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting photo");
        }





    }
    }


