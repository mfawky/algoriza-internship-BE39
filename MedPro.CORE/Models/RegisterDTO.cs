using MedPro.CORE.Constants;


namespace MedPro.CORE.Models
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public AccountType AccountType { get; set; }
        public BloodType BloodType { get; set; }
        public Gender Gender { get; set; }
    }
}
