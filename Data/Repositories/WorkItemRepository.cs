using System;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using Models.Exceptions;
using Models.Read;

namespace Data.Repositories
{
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly BwAdminContext _context;
        private readonly IMapper _mapper;

        public WorkItemRepository(BwAdminContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkItemDto> EditWorkItem(Guid id, WorkItemDto workItem)
        {
            var item = await _context.FindAsync<WorkItem>(id);
            if (item == null) throw new NotFoundException($"");
            var itemToUpdate = _mapper.Map<WorkItem>(workItem);

            _context.Update(itemToUpdate);
            await _context.SaveChangesAsync();

            return workItem;
        }
    }
}
