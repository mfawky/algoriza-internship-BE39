using MedPro.CORE.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.Models
{
    public class Booking 
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public int PatientId { get; set; }
        public int Price { get; set; }
        public string BookingDay { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Patient Patient { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
