using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int BookingID { get; set; }
        public TimeSpan BookingSchedule { get; set; }
        public Booking Booking { get; set; }
    }
}
