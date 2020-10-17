using System;
using System.Threading.Tasks;
using BWAdminUi.Server.Data;
using BWAdminUi.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BWAdminUi.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private const string UserName = "Brent";

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> GetDefaultUserId()
        {
            return (await _context.AppUsers.FirstOrDefaultAsync(x => x.Username == UserName)).Id;
        }
    }
}
