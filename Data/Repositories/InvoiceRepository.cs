using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(BwAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
