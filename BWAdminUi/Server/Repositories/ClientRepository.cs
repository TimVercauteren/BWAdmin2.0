﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BWAdminUi.Server.Data;
using BWAdminUi.Server.Repositories.Abstracts;
using BWAdminUi.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Exceptions;
using Models.Post;
using Models.Read;

namespace BWAdminUi.Server.Repositories
{
    public class ClientRepository : Repository<global::Data.Entities.Client>, IClientRepository
    {
        private readonly IUserRepository _userRepository;

        public ClientRepository(ApplicationDbContext context, IMapper mapper, IUserRepository userRepository) : base(context, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            return await Context.Clients
                .Where(c => !c.IsDeleted)
                .Include(c => c.Info)
                .Select(x => Mapper.Map<ClientDto>(x)).ToListAsync();
        }

        public async Task<ClientDetailDto> GetClient(Guid id)
        {
            var client = await Context.Clients
                .Include(c => c.Info)
                .Include(c => c.Offers)
                .Include(c => c.Invoices)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (client == null) throw new NotFoundException(id.ToString());
            if (client.IsDeleted) throw new BusinessValidationException($"This client has been deleted, contact support to restore it");

            return Mapper.Map<ClientDetailDto>(client);
        }

        public async Task<global::Data.Entities.Client> AddClient(global::Data.Entities.Client client, string userId)
        {
            if (client.Id == Guid.Empty)
            {
                client.Id = Guid.NewGuid();
            }

            if (client.Info.Id == Guid.Empty)
            {
                client.Info.Id = Guid.NewGuid();
            }

            client.UserId = userId;
            client.ClientReference = GetLastUsedClientReference();

            await Context.Clients.AddAsync(client);
            await Context.SaveChangesAsync();

            return client;
        }

        #region Privates

        private int GetLastUsedClientReference()
        {
            if (!Context.Clients.Any())
            {
                return 1;
            }

            return Context.Clients.Select(x => x.ClientReference).Max() + 1;
        }

        #endregion
    }
}
