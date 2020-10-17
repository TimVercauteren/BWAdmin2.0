using System;
using System.Threading.Tasks;

namespace BWAdminUi.Server.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> GetDefaultUserId();
    }
}
