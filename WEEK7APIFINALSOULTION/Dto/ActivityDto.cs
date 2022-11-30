using System.ComponentModel.DataAnnotations;

namespace WEEK7APIFINALSOULTION.Dto
{
    public class ActivityDto
    {
        
        public string? Description { get; set; }
        public DateTime Starttime { get; set; }
        public int Duration { get; set; }
        public string? Email { get; set; }
    }
}
