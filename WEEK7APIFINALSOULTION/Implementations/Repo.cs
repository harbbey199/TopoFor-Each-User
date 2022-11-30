using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using WEEK7APIFINALSOULTION.Dto;

using WEEK7APIFINALSOULTION.Model;
using WEEK7APIFINALSOULTION.Service;
using static System.Reflection.Metadata.BlobBuilder;

namespace WEEK7APIFINALSOULTION.Implementations
{
    public class Repo:IRepo
    {
        private readonly ActivityContexts _context;

        public Repo(ActivityContexts contexts)
        {
            _context = contexts;
        }
        public async Task<UserResponseManager> AddActivityAsync(int userid, ActivityDto act)
        {
            var response = await _context.users.FirstOrDefaultAsync(x => x.Id == userid);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };

           
            
            var activity = new Activity
            {
                Description = act.Description,
                Duration = act.Duration,
                Starttime = DateTime.Now,
                Email = act.Email,
                UserId = userid
            };
            _context.Activitives.Add(activity);
            await _context.SaveChangesAsync();
            return new UserResponseManager
            {
                Message = "Activity Added Successfully",
                IsSuccess = true
            };
        }

        public async Task<List<ActivityDto>> GetUserActivitiesAsync(int userId)
        {
            
            var response = await _context.Activitives.Where(x => x.UserId == userId)
                .Select(x=> new ActivityDto
                {
                    Description=x.Description,
                    Duration=x.Duration,
                    Email=x.Email,
                }).ToListAsync();
            if (response == null)
                return new List<ActivityDto> ();
       

            return response;
        }

        public async Task<ActivityDto> GetUserActivityAsync(int userId, int ActivityId)
        {
            var response = await _context.Activitives.Where(x => x.UserId == userId)
                .Select(x => new Activity
                {
                    Id = x.Id,
                    Description = x.Description,
                    Duration = x.Duration,
                    Email = x.Email,
                }).ToListAsync();
            if (response == null)
                return new ActivityDto
                {
                    Description = " User Not Found",
                };
            var res = response.Where(x=>x.Id== ActivityId).Select(x=>x).FirstOrDefault();
            if (res == null)
                return new ActivityDto
                {
                    Description = "Activity Not Found"
                };
            return new ActivityDto
            {
                Description = res.Description,
                Starttime = res.Starttime,
                Email = res.Email,
            };


        }

        public async Task<UserResponseManager> DeleteActivityAsync(int UserId, string Description)
        {
            var response = await _context.Activitives.Where(x => x.UserId == UserId).Select(x=>x).ToListAsync();
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not found",
                    IsSuccess = false
                };
            var res = response.FirstOrDefault(x => x.Description == Description);
            if (res == null)
                return new UserResponseManager
                {
                    Message = "Activity Not Found",
                    IsSuccess = false
                };
            _context.Activitives.Remove(res);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = "Activity Deleted Successfully",
                IsSuccess = true,
            };
        }

        public async Task<UserResponseManager> PartiallyUpdateActivityAsync(int userId,
            int actId, JsonPatchDocument<Activity> patchDocument)
        {
            var response = await _context.Activitives.Where(x=> x.UserId == userId).Select(x=>x).ToListAsync();
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            var res = response.Where(x => x.Id == actId).Select(x => x).FirstOrDefault();
            if (res == null)
                return new UserResponseManager
                {
                    Message = "Activity Not Found",
                    IsSuccess = false,
                };
            var user = new Activity
            {
                Description = res.Description,
                Duration = res.Duration
            };
            patchDocument.ApplyTo(user);
            res.Description = user.Description;
            res.Duration = user.Duration;
            _context.Activitives.Update(res);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = "Partial Update Successful",
                IsSuccess = true,
            };

        }

        public async Task<UserResponseManager> FullActivityUpdate(int UserId, int ActivityId, ActivityDto act)
        {
            var response = await _context.Activitives.Where(x => x.UserId == UserId).Select(x => x).ToListAsync();
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            var res = response.FirstOrDefault(x => x.Id == ActivityId);
            if (res == null)
                return new UserResponseManager
                {
                    Message = "Activity Not Found",
                };
            
            res.Duration = act.Duration;
            res.Description = act.Description;
            res.Email = act.Email;
            _context.Activitives.Update(res);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = "Update Successfully",
                IsSuccess = true,
            };
            
        }
    }
}
