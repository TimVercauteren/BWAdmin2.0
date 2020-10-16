using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Exceptions;

namespace Data.Repositories
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {

        public OfferRepository(BwAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<Offer>> GetAllForClient(Guid clientId)
        {
            if (await Context.FindAsync<Client>(clientId) == null) throw new NotFoundException(clientId.ToString());

            return await Context.Offers.Where(x => x.ClientId == clientId).ToListAsync();
        }

        public async Task<Offer> AddOfferWithItems(Offer offer, Guid clientId)
        {
            var offerId = offer.Id;
            offer.ClientId = clientId;
            if (offerId == Guid.Empty)
            {
                offerId = Guid.NewGuid();
            }

            foreach (var offerWorkItem in offer.WorkItems)
            {
                offerWorkItem.OfferId = offerId;
            }

            await Context.Offers.AddAsync(offer);
            await Context.SaveChangesAsync();

            return offer;
        }
    }
}
