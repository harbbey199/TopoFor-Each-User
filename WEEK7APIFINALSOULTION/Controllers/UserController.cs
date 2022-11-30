using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "mustbeauser")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("User")]
        public async Task<IActionResult> PostUserAsync([FromBody]UserDto User)
        {
            var result = await _userRepo.AddUserAsync(User);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUserAsync()
        {
           var result = await _userRepo.GetAllUserWithoutActivitiesAsync();
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("User")]
        public async Task<IActionResult> DeleteAsync(int userId) 
        {
            var result = await _userRepo.DeleteUserAsync(userId);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPatch("User")]
        public async Task<IActionResult> PatchAsync(int userId, [FromBody]
            JsonPatchDocument<UserDto> patchDocument)
        {
            var result = await _userRepo.PartialUpateUserAsync(userId, patchDocument);
            if( result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("User")]
        public async Task<IActionResult> UpdateAsync(int userId,[FromBody] UserDto userDto)
        {
            var result =await  _userRepo.FullUpdateUserAsync(userId, userDto);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
