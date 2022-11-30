using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Model;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "mustbeauser")]
    public class ActivityController : ControllerBase
    {
        private readonly IRepo _repostory;

        public ActivityController(IRepo repo)
        {
            _repostory = repo;
        }
        [HttpPost("Activity")]
        public async Task<IActionResult> AddAsync(int id, ActivityDto act)
        {
            var result = await _repostory.AddActivityAsync(id, act);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("Activicties")]
        public async Task<IActionResult> GetAllAsync(int userId)
        {
            var result = await _repostory.GetUserActivitiesAsync(userId);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Activity")]
        public async Task<IActionResult> GetAsync(int UserId, int ActivityId)
        {
            var result = await _repostory.GetUserActivityAsync(UserId, ActivityId);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("Activity")]
        public async Task<IActionResult> DeleteAsync(int UserId, string Description)
        {
            var result = await _repostory.DeleteActivityAsync(UserId, Description);
            if(result== null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPatch("Activity")]

        public async Task<IActionResult> PartialUpdate(int userId,
            int actId, JsonPatchDocument<Activity> patchDocument)
        {
            var result = await _repostory.PartiallyUpdateActivityAsync(userId, actId, patchDocument);
            if( result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("Activity")]
        public async Task<IActionResult> FullUpdate(int UserId, int ActivityId, [FromBody]ActivityDto act)
        {
            var result = await _repostory.FullActivityUpdate(UserId, ActivityId, act);
            if(result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }



    }
}
