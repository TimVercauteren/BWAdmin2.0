using System;
using System.Threading.Tasks;
using BWAdmin2._0.Setup;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Read;

namespace BWAdmin2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkLinesController : ControllerBase
    {
        private readonly IWorkItemRepository _repository;

        public WorkLinesController(IWorkItemRepository repository)
        {
            _repository = repository;
        }

        [ProducesResponseType(typeof(WorkItemDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpPut("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid id, [FromBody] WorkItemDto workItem)
        {
            var result = await _repository.EditWorkItem(id, workItem);

            return Ok(result);
        }
    }
}
