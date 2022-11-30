using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Model;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Implementations
{
    public class Repostory : IRepostory
    {
        private readonly ActivityContexts _context;

        public Repostory(ActivityContexts contexts)
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
            var maxid = _context.users.SelectMany(c => c.Users).Max(prop => prop.Id);
            var activity = new Activity
            {
                Id = ++maxid,
                Description = act.Description,
                Duration = act.Duration,
                Starttime = DateTime.Now,
                Email = act.Email
            };
            response.Users.Add(activity);
            _context.Activitives.Add(activity);
            await _context.SaveChangesAsync();
            return new UserResponseManager
            {
                Message = "Activity Added Successfully",
                IsSuccess = true
            };

        }

        public async Task<IEnumerable<Activity>> GetUserActivitiesAsync(int UserId)
        {
            var response = await _context.users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (response == null)
                return Enumerable.Empty<Activity>();
            return response.Users;

        }

        public async Task<Activity> GetUserActivityAsync(int UserId, int ActivityId)
        {
            var response = await _context.users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (response == null)
                return new Activity
                {
                    Description = " User Not Found",
                };
            var res = response.Users.FirstOrDefault(x => x.Id == ActivityId);
            if (res == null)
                return new Activity
                {
                    Description="Activity Not Found"
                };
            return res;


        }

        public async Task<UserResponseManager> DeleteActivityAsync(int UserId, int ActivityId)
        {
            var response = await _context.users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not found",
                    IsSuccess = false
                };
            var res = response.Users.FirstOrDefault(x => x.Id == ActivityId);
            if (res == null)
                return new UserResponseManager
                {
                    Message = "Activity Not Found",
                    IsSuccess = false
                };
            response.Users.Remove(res);
            _context.Activitives.Remove(res);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = "Activity Deleted Successfully",
                IsSuccess = true,
            };
        }

        public async Task<UserResponseManager> PartiallyUpdateActivityByEmailAsync(string email,
            int actId, JsonPatchDocument<Activity> patchDocument)
        {
            var response = await _context.users.FirstOrDefaultAsync(x => x.Email == email);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            var res = response.Users.FirstOrDefault(x => x.Id == actId);
            if (res == null)
                return new UserResponseManager
                {
                    Message = "Activity Not Found",
                    IsSuccess = false,
                };
            response.Users.Remove(res);
            var user = new Activity
            {
                Description = res.Description,
                Duration = res.Duration
            };
            patchDocument.ApplyTo(user);
            res.Duration = user.Duration;
            res.Duration = user.Duration;
            response.Users.Add(user);
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
            var response = await _context.users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            var res = response.Users.FirstOrDefault(x => x.Id == ActivityId);
            if (res == null)
                return new UserResponseManager
                {
                    Message = "Activity Not Found",
                };
            response.Users.Remove(res);
            res.Duration = act.Duration;
            res.Description = act.Description;
            res.Email = act.Email;
            response.Users.Add(res);
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
//        public async Task<ActivityDto > GetActivityEmail(string Email)
//        {
//            var activity = _context.Activitives.Where(x =>
//            x.Email.ToLower().Trim() == Email.ToLower().Trim()).FirstOrDefault();

//            var user = new ActivityDto
//            {
//                Description = activity.Description,
//                Starttime = activity.Starttime,
//                Duration = activity.Duration,
//                Email = activity.Email
//            };
//            return user;
            
//        }

//        public async Task<ActivityDto> DeleteActivityId(int id)
//        {
//            var activity = _context.Activitives.Where(x=> x.id == id).FirstOrDefault();
//            _context.Remove(activity);
//            _context.SaveChanges();
//            return new ActivityDto
//            {
//                Description = activity.Description,
//                Starttime = activity.Starttime,
//                Duration = activity.Duration,
//                Email = activity.Email
//            };

//        }

//        public async Task<List<ActivityDto>> GetActivities()
//        {
//            var activities = _context.Activitives.Select(x =>
//            new ActivityDto
//            {
//                Description=x.Description,
//                Starttime=x.Starttime,
//                Duration=x.Duration,
//                Email=x.Email
//            })
                
//                .ToList();

//            return activities;
//        }

//        public async  Task<ActivityDto> GetActivityId(int id)
//        {
//            var activity = _context.Activitives.Where(x => x.id == id).FirstOrDefault();
//            return new ActivityDto
//            {
//                Description = activity.Description,
//                Starttime = activity.Starttime,
//                Duration = activity.Duration,
//                Email = activity.Email
//            };
//        }

//        public async  Task<ActivityDto> SearchByKeyword(string keyword)
//        {
//           var result = _context.Activitives.Where(x =>
//            x.Description.Contains(keyword)).FirstOrDefault();
//            return new ActivityDto
//            {
//                Description = result.Description,
//                Starttime = result.Starttime,
//                Duration = result.Duration,
//                Email = result.Email
//            };
//        }

//        public async Task<string> UpdateActivity(Activity act)
//        {
//            _context.Update(act);
//            _context.SaveChanges();
//            return "Data update successfully";
//        }
//    }
//}
