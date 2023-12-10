using MedPro.CORE.IRepositories;
using MedPro.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedPro.EF.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser, string>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task DeleteUserAsync(string userId)
        {
            try
            {
                var user = await _context.Users.Include(b => b.Patients).
                    FirstOrDefaultAsync(b => b.Id == userId);

                _context.Remove(user);
            }
            catch
            {
                Console.WriteLine("Exception Happened");
            }
        }
    }
}

