using MedPro.Constants;
using MedPro.CORE.Models;
using MedPro.DTOs;
using MedPro.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthRepository _authService;



        public AccountController(UserManager<ApplicationUser> userManager,
            IAuthRepository authService)
        {
            _userManager = userManager;
            _authService = authService;

        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO model)
        {
            var result = await _authService.AddUserAsync(model);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AuthDTO>> Login([FromBody] LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _authService.GetUserCredentialsAsync(model);

                    if (result.IsAuthenticated)
                        return Ok(result);

                    return BadRequest(result);

                }
                catch
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
