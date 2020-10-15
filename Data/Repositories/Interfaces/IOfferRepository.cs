using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository
    {
        Task<IEnumerable<Offer>> GetAllForClient(Guid clientId);
    }
}
