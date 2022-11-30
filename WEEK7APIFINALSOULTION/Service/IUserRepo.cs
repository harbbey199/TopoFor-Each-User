using Microsoft.AspNetCore.JsonPatch;
using WEEK7APIFINALSOULTION.Dto;

namespace WEEK7APIFINALSOULTION.Service
{
    public interface IUserRepo
    {
        Task<UserResponseManager> AddUserAsync(UserDto User);
        
        Task<IEnumerable<UserDto>> GetAllUserWithoutActivitiesAsync();
       
        Task<UserResponseManager> PartialUpateUserAsync(int userId,
            JsonPatchDocument<UserDto> patchDocument);
        Task<UserResponseManager> FullUpdateUserAsync(int userId, UserDto userDto);
        Task<UserResponseManager> DeleteUserAsync(int userId);

    }
}
