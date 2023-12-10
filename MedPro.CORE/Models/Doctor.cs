using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int SpecID { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
