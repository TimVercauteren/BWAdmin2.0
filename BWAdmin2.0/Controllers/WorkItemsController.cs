using System;
using System.Threading.Tasks;
using AutoMapper;
using BWAdmin2._0.Setup;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Read;

namespace BWAdmin2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkItemsController : ControllerBase
    {
        private readonly IWorkItemRepository _repository;
        private readonly IMapper _mapper;

        public WorkItemsController(IWorkItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(WorkItemDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpPut("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid id, [FromBody] WorkItemDto workItem)
        {
            var result = await _repository.UpdateEntity(id, _mapper.Map<WorkItem>(workItem));

            return Ok(MapEntity(result));
        }

        private IDto MapEntity(IEntity entity)
        {
            return _mapper.Map<IDto>(entity);
        }
    }
}
