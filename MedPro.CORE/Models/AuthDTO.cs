namespace MedPro.CORE.Models
{
    public class AuthDTO
    {
        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
