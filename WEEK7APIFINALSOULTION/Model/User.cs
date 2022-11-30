using System.ComponentModel.DataAnnotations;

namespace WEEK7APIFINALSOULTION.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }

        public ICollection<Activity> Users { get; set; } = new List<Activity>();
    }
}
