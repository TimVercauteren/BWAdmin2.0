using System;
using System.Threading.Tasks;
using Models.Read;

namespace Data.Repositories.Interfaces
{
    public interface IWorkItemRepository
    {
        Task<WorkItemDto> EditWorkItem(Guid id, WorkItemDto workItem);
    }
}
