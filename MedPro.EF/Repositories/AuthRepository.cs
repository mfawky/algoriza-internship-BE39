using MedPro.CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MedPro.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManger;




        public AuthRepository(UserManager<ApplicationUser> userManger)
        {
            _userManger = userManger;
        }

        public async Task<IdentityResult> AddUserAsync(RegisterDTO model)
        {

            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                AccountType = model.AccountType,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                ImageUrl = model.ImageUrl,
                BloodType = model.BloodType,
                Gender = model.Gender
            };

            return await _userManger.CreateAsync(user, model.Password);

        }

        public async Task<AuthDTO> GetUserCredentialsAsync(LoginDTO model)
        {
            var user = await _userManger.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.PhoneNumber == model.Email);

            return new AuthDTO
            {
                IsAuthenticated = true,
                UserId = user.Id,
                Message = "User is authenticated now"
            };

        }
    }
}
