using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class Patient
    {
        public string Email { get; set; }
        public int PatientId { get; set; }
        public List<Booking> Bookings { get; set; }
        public ApplicationUser User { get; set; }
    }
}
