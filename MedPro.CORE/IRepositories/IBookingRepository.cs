using MedPro.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.CORE.IRepositories
{
    public interface IBookingRepository
    {
        void AddBooking(int Bookingid, Booking bookings);
        void DeleteBooking(int Bookingid);
    }
}
