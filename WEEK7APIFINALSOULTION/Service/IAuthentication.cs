using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Model;

namespace WEEK7APIFINALSOULTION.Service
{
    public interface IAuthentication
    {
        Task<UserResponseManager> LoginUserAsync(LoginDto login);
    }
}
