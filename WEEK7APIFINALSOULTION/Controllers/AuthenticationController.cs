using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authen;

        public AuthenticationController(IAuthentication authentication)
        {
            _authen = authentication;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto login)
        {
            var result = await  _authen.LoginUserAsync(login);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
