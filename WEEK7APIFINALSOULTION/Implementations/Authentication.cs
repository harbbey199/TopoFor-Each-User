using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Implementations
{
    public class Authentication : IAuthentication
    {
        private readonly ActivityContexts _contexts;
        private readonly IConfiguration _config;

        public Authentication(ActivityContexts contexts, IConfiguration config)
        {
            _contexts = contexts;
            _config = config;
        }

        public async Task<UserResponseManager> LoginUserAsync(LoginDto login)
        {
            var response =await _contexts.users.FirstOrDefaultAsync(x=> x.Email == login.Email);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            var res = response.Email == login.Email;
            if (!res)
                return new UserResponseManager
                {
                    Message = "Invalid Password",
                    IsSuccess = false,
                };
            var claims = new[]
            {
               new Claim("Email", login.Email),
               new Claim("Id",response.Id.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                _config["AuthSettings:Key"]
                ));
            var token = new JwtSecurityToken(
                _config["AuthSettings:Issuer"],
                _config["AuthSettings:Audience"],
                claims: claims, expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            string tokenHasString = new JwtSecurityTokenHandler().WriteToken(token);
            return new UserResponseManager
            {
                Message = tokenHasString,
                IsSuccess = true,
                Expiredate = token.ValidTo
            };
        }
        

    }
}
