using MedPro.CORE.IRepositories;
using MedPro.CORE.Models;
using MedPro.DTOs;
using MedPro.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MedPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IGenericRepository<Doctor, string> _genericRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public DoctorController(IGenericRepository<Doctor, string> genericRepository, 
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, 
            IUserRepository userRepository)
        {

            _genericRepository = genericRepository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetListOfDoctors() => Ok(await _genericRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDoctor(string id) => Ok(await _genericRepository.FindByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult> AddDoctor(DoctorDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var doctor = new Doctor
                    {
                        SpecID = model.SpecID,
                        specialization = model.specialization

                    };
                    return Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return BadRequest();
        }
        [HttpDelete("Delete Doctor")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAccount(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUserAsync(userId);
                return NoContent();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}


