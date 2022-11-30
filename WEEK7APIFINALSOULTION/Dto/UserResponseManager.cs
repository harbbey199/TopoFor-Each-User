namespace WEEK7APIFINALSOULTION.Dto
{
    public class UserResponseManager
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Expiredate { get; set; }
        public string? Error { get; set; }
    }
}
