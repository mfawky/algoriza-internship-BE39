using Azure.Core;
using MedPro.CORE.IRepositories;
using MedPro.CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IGenericRepository<Patient, string> _genericRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public BookingController(IGenericRepository<Patient, string> genericRepository,
            IUserRepository userRepository,
            UserManager<ApplicationUser> userManager,
            IBookingRepository bookingRepository)
        {

            _genericRepository = genericRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        [HttpPost("Add Booking/{id}")]
        public IActionResult AddBooking([FromRoute] int id, [FromBody] Booking booking)
        {
            _bookingRepository.AddBooking(id, booking);
            return Ok();

        }
        [HttpPost("Update Booking")]
        public IActionResult updateBooking([FromRoute] string id, [FromBody] Patient booking)
        {
            _genericRepository.UpdateAsync(id, booking);
            return Ok();
        }
        [HttpDelete("Delete booking/{id}")]
        public IActionResult delteBooking(int id)
        {
            _bookingRepository.DeleteBooking(id);
            return Ok();
        }
    }
}
