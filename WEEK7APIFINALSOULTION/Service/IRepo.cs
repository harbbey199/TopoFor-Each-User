using Microsoft.AspNetCore.JsonPatch;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Helper;
using WEEK7APIFINALSOULTION.Model;

namespace WEEK7APIFINALSOULTION.Service
{
    public interface IRepo
    {
        Task<UserResponseManager> AddActivityAsync(int userid, ActivityDto act);
        Task<List<ActivityDto>> GetUserActivitiesAsync(int userId);
        Task<ActivityDto> GetUserActivityAsync(int UserId, int ActivityId);
        Task<UserResponseManager> DeleteActivityAsync(int UserId, string Description);
        Task<UserResponseManager> PartiallyUpdateActivityAsync(int userId,
            int actId, JsonPatchDocument<Activity> patchDocument);
        Task<UserResponseManager> FullActivityUpdate(int UserId, int ActivityId, ActivityDto act);
    }
}
