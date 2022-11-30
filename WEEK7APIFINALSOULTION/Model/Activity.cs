using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEEK7APIFINALSOULTION.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        public DateTime Starttime { get; set; }= DateTime.Now;
        public int Duration { get; set; }
        public string? Email { get; set; }

    }
}
