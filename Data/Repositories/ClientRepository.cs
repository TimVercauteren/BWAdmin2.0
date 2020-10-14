using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Exceptions;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BwAdminContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ClientRepository(BwAdminContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClient(Guid id)
        {
            var client = await _context.Clients
                .Include(c => c.Info)
                .Include(c => c.Offers)
                .Include(c => c.Invoices)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (client == null) throw new NotFoundException($"Client with id {id} was not found");
            return client;
        }

        public async Task<Client> AddClient(Models.Post.ClientDto clientDto)
        {
            var userId = await _userRepository.GetDefaultUserId();

            if (clientDto.Id == Guid.Empty)
            {
                clientDto.Id = Guid.NewGuid();
            }

            if (clientDto.Info.Id == Guid.Empty)
            {
                clientDto.Info.Id = Guid.NewGuid();
            }
            var mappedClient = _mapper.Map<Client>(clientDto);

            mappedClient.UserId = userId;
            await _context.Clients.AddAsync(mappedClient);
            await _context.SaveChangesAsync();

            return mappedClient;
        }
    }
}
