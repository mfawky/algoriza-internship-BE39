namespace MedPro.CORE.Models
{
    public class LoginDTO
    {
        public bool IsAuthenticated { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
