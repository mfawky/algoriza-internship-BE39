using MedPro.CORE.Models;

using Microsoft.AspNetCore.Identity;

namespace MedPro.Services
{
    public interface IAuthRepository
    {
        Task<IdentityResult> AddUserAsync(RegisterDTO model);

        Task<AuthDTO> GetUserCredentialsAsync(LoginDTO model);


    }
}
