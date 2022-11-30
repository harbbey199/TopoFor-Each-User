using WEEK7APIFINALSOULTION.Model;

namespace WEEK7APIFINALSOULTION.Dto
{
    public class UserDtoWithActivities
    {
        public string? UserName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }

        public ICollection<Activity> Users { get; set; } = new List<Activity>();
    }
}
