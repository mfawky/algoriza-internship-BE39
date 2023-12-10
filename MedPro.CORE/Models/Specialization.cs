using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorSpecialization { get; set; }
        public Doctor Doctor { get; set; }
    }
}
