using System;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> GetDefaultUserId();
    }
}
