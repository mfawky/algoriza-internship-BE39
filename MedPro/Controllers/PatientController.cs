using MedPro.CORE.IRepositories;
using MedPro.CORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MedPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IGenericRepository<Patient, string> _genericRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public PatientController(IGenericRepository<Patient, string> genericRepository,
            IUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {

            _genericRepository = genericRepository;
            _userRepository = userRepository;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<ActionResult> GetListOfPatient() => Ok(await _genericRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPatient(string id) => Ok(await _genericRepository.FindByIdAsync(id));

        [HttpDelete("Delete Patient")]
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

