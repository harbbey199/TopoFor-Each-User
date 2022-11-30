using Microsoft.AspNetCore.JsonPatch;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Model;

namespace WEEK7APIFINALSOULTION.Service
{
    public interface IRepostory
    {
        
        Task<UserResponseManager> AddActivityAsync(int userid, ActivityDto act);
        Task<IEnumerable<Activity>> GetUserActivitiesAsync(int UserId);
        Task<Activity> GetUserActivityAsync(int UserId, int ActivityId);
        Task<UserResponseManager> DeleteActivityAsync(int UserId, int ActivityId);
        Task<UserResponseManager> PartiallyUpdateActivityByEmailAsync(string email,
            int actId, JsonPatchDocument<Activity> patchDocument);
        Task<UserResponseManager> FullActivityUpdate(int UserId, int ActivityId, ActivityDto act);

    }
}
