using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BWAdminUi.Server.Data;
using BWAdminUi.Server.Repositories.Interfaces;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Post;
using Models.Read;

namespace BWAdminUi.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Guid> GetDefaultUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<UserWithInfoDto> GetUserWithInfo(string id)
        {
            return await _context.AppUsers
                .Join(_context.PersonInfos, a => a.Id, i => i.UserId, (a, i) => new UserWithInfoDto()
                {
                    UserInfo = _mapper.Map<PersonInfoDto>(i),
                    UserId = a.Id
                })
                .FirstOrDefaultAsync(au => au.UserId == id);

        }
    }
}
