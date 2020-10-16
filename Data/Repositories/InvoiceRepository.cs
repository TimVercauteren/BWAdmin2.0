using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories.Abstracts;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Exceptions;

namespace Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(BwAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<Invoice>> GetAllForClient(Guid clientId)
        {
            if (await Context.FindAsync<Client>(clientId) == null) throw new NotFoundException(clientId.ToString());

            return await Context.Invoices.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<Invoice> AddInvoiceWithItems(Invoice invoice, Guid clientId, Guid offerId)
        {
            var invoiceId = invoice.Id;
            invoice.ClientId = clientId;
            invoice.OfferId = offerId;

            if (invoiceId == Guid.Empty)
            {
                invoiceId = Guid.NewGuid();
            }

            foreach (var workItem in invoice.ExtraWorkItem)
            {
                workItem.InvoiceId = invoiceId;
            }

            await Context.Invoices.AddAsync(invoice);
            await Context.SaveChangesAsync();

            return invoice;
        }
    }
}
