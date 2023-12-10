using Azure.Core;
using MedPro.CORE.IRepositories;
using MedPro.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.EF.Repositories
{
    public class BookingRepository :IBookingRepository
    {
        private readonly IGenericRepository<Booking, string> _genericRepository;
        private readonly ApplicationDbContext _context;
        public BookingRepository(IGenericRepository<Booking, string> baseRequest, ApplicationDbContext context)
        {
            _genericRepository = baseRequest;
            _context = context;

        }
        public void AddBooking(int Bookingid, Booking bookings)
        {
            var Booking = new Booking
            {
                Id = Bookingid,
                BookingStatus = bookings.BookingStatus,


            };
            _context.Bookings.Update(Booking);

        }

        public void DeleteBooking(int Bookingid)
        {
            var booking = new Booking() { Id = Bookingid };
            _context.Bookings.Remove(booking);
        }
        public IEnumerable<Booking> GetAllByPage(int id, int page = 1, int pageSize = 10)
        {

            var result = _context.Set<Booking>().Where(x => id == x.DoctorId).ToList();
            return result.Skip(page - 1 * pageSize).Take(pageSize).ToList();
        }
    }
}

