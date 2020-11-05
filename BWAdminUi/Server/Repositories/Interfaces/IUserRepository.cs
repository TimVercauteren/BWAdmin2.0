using System;
using System.Threading.Tasks;
using Data.Entities;
using Models.Read;

namespace BWAdminUi.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> GetDefaultUserId();
        Task<UserWithInfoDto> GetUserWithInfo(string id);
    }
}
