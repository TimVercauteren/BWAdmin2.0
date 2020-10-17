using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace BWAdminUi.Server.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository
    {
        Task<IEnumerable<Offer>> GetAllForClient(Guid clientId);
        Task<Offer> AddOfferWithItems(Offer offer, Guid clientId);
    }
}
