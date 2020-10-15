using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Models.Post;
using Models.Read;

namespace Data.Repositories.Interfaces
{
    public interface IClientRepository : IRepository
    {
        Task<IEnumerable<ClientDto>> GetAll();
        Task<ClientDetailDto> GetClient(Guid id);
        Task<Client> AddClient(Client client);
    }
}
