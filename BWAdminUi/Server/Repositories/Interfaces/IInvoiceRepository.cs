using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace BWAdminUi.Server.Repositories.Interfaces
{
    public interface IInvoiceRepository : IRepository
    {
        Task<IEnumerable<Invoice>> GetAllForClient(Guid clientId);
        Task<Invoice> AddInvoiceWithItems(Invoice map, Guid clientId, Guid offerId);
    }
}
