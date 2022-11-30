using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using WEEK7APIFINALSOULTION.Dto;
using WEEK7APIFINALSOULTION.Model;
using WEEK7APIFINALSOULTION.Service;

namespace WEEK7APIFINALSOULTION.Implementations
{
    public class UserRepo:IUserRepo
    {
        private readonly ActivityContexts _context;

        public UserRepo(ActivityContexts contexts)
        {
            _context = contexts;
        }
        public async Task<UserResponseManager> AddUserAsync(UserDto User)
        {
            var user = new User
            {
                UserName = User.UserName,
                Email = User.Email,
                PassWord = User.PassWord,
                RegisteredDate = DateTime.Now,
            };
            await _context.users.AddAsync(user);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = "User successful created with activity",
                IsSuccess = true
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllUserWithoutActivitiesAsync()
        {
            var response = await _context.users.Select(prod => new UserDto
            {
                UserName = prod.UserName,
                Email= prod.Email,
                PassWord= prod.PassWord,
            }).ToListAsync();
            return response;
        }

        public async Task<UserResponseManager> PartialUpateUserAsync(int userId,
            JsonPatchDocument<UserDto> patchDocument)
        {
            var response =await  _context.users.FirstOrDefaultAsync(x=> x.Id==userId);
            if (response == null)
                return new UserResponseManager
                {
                    Message = " User not found",
                    IsSuccess = false,
                };
            var user = new UserDto
            {
                UserName = response.UserName,
                Email = response.Email,
                PassWord = response.PassWord
            };

            patchDocument.ApplyTo(user);
            response.UserName = user.UserName;
            response.Email = user.Email;
            response.PassWord = user.PassWord;
            _context.Update(response);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = "Successfully updated",
                IsSuccess = true,
            };
        }

        public async Task<UserResponseManager> DeleteUserAsync(int userId)
        {
            var response = await _context.users.FirstOrDefaultAsync(x=> x.Id==userId);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            var acts = response.Users.ToList();
            _context.Remove(response);
            _context.Activitives.RemoveRange(acts);
            await _context.SaveChangesAsync();
            return new UserResponseManager
            {
                Message = "User updated",
                IsSuccess = true,
            };
        }

        public async Task<UserResponseManager> FullUpdateUserAsync(int userId, UserDto userDto)
        {
            var response = await _context.users.FirstOrDefaultAsync(x=>x.Id==userId);
            if (response == null)
                return new UserResponseManager
                {
                    Message = "User Not Found",
                    IsSuccess = false,
                };
            response.UserName = userDto.UserName;
            response.Email = userDto.Email;
            response.PassWord = userDto.PassWord;
            _context.users.Update(response);
            _context.SaveChanges();
            return new UserResponseManager
            {
                Message = " User Updated",
                IsSuccess = true,
            };
        }
    }
}
