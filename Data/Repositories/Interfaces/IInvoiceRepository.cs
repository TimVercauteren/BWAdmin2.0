using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IInvoiceRepository : IRepository
    {
        Task<IEnumerable<Invoice>> GetAllForClient(Guid clientId);
        Task<Invoice> AddInvoiceWithItems(Invoice map, Guid clientId, Guid offerId);
    }
}
