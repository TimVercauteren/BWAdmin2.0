using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BWAdminUi.Server.Data;
using BWAdminUi.Server.Repositories.Abstracts;
using BWAdminUi.Server.Repositories.Interfaces;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Exceptions;

namespace BWAdminUi.Server.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<Invoice>> GetAllForClient(Guid clientId)
        {
            if (await Context.FindAsync<global::Data.Entities.Client>(clientId) == null) throw new NotFoundException(clientId.ToString());

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
