using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Post;
using Models.Read;

namespace BWAdminUi.Server.Repositories.Interfaces
{
    public interface IClientRepository : IRepository
    {
        Task<IEnumerable<ClientDto>> GetAll();
        Task<ClientDetailDto> GetClient(Guid id);
        Task<global::Data.Entities.Client> AddClient(global::Data.Entities.Client client, string userId);
    }
}
