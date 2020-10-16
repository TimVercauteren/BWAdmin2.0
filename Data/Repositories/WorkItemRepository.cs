using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class WorkItemRepository : Repository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(BwAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
