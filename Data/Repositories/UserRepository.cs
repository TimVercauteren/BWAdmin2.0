using System;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BwAdminContext _context;
        private const string UserName = "Brent";

        public UserRepository(BwAdminContext context)
        {
            _context = context;
        }

        public async Task<Guid> GetDefaultUserId()
        {
            return (await _context.Users.FirstOrDefaultAsync(x => x.Username == UserName)).Id;
        }
    }
}
