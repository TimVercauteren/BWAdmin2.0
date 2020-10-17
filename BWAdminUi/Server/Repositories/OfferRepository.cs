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
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {

        public OfferRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<Offer>> GetAllForClient(Guid clientId)
        {
            if (await Context.FindAsync<global::Data.Entities.Client>(clientId) == null) throw new NotFoundException(clientId.ToString());

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
