using MedPro.CORE.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public AccountType AccountType { get; set; }
        public BloodType BloodType { get; set; }
        public Gender Gender { get; set; }


    }
}
