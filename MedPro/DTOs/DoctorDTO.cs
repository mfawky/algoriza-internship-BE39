using MedPro.CORE.Constants;
using MedPro.CORE.Models;

namespace MedPro.DTOs
{
    public class DoctorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public AccountType AccountType { get; set; }
        public Gender Gender { get; set; }
        public int SpecID { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Specialization specialization { get; set; }
    }
}
