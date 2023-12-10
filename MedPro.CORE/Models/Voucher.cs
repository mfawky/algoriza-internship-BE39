using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool IsValid { get; } = false;
        public DateTime ValidTill { get; set; }
        public string DiscountValue { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
