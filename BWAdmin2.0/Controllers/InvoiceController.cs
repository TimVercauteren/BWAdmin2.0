using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BWAdmin2._0.Setup;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Read;

namespace BWAdmin2._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IInvoiceRepository _repository;
        private readonly IMapper _mapper;

        public InvoiceController(ILogger<ClientsController> logger, IInvoiceRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(IEnumerable<InvoiceDto>), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet("{clientId}/all")]
        public async Task<IActionResult> GetAll([FromRoute] Guid clientId)
        {
            var result = await _repository.GetAllForClient(clientId);

            return Ok(MapEntities(result));
        }

        // todo :: invoice full dto for pdf Generator
        [ProducesResponseType(typeof(InvoiceDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _repository.GetEntity<Invoice>(id);
            return Ok(MapEntity(result));
        }

        [ProducesResponseType(typeof(InvoiceDto), 201)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpPost("{clientId}/{offerId}")]
        public async Task<IActionResult> AddInvoiceForClient([FromBody] InvoiceDto invoice, [FromRoute] Guid clientId, [FromRoute] Guid offerId)
        {
            var result = await _repository.AddInvoiceWithItems(_mapper.Map<Invoice>(invoice), clientId, offerId);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, MapEntity(result));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(InvoiceDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        public async Task<IActionResult> UpdateClient([FromBody] InvoiceDto invoice, [FromRoute] Guid invoiceId)
        {
            var result = await _repository.UpdateEntity(invoiceId, _mapper.Map<Invoice>(invoice));

            return Ok(MapEntity(result));
        }

        private IDto MapEntity(IEntity entity)
        {
            return _mapper.Map<IDto>(entity);
        }

        private IEnumerable<IDto> MapEntities(IEnumerable<IEntity> entities)
        {
            return _mapper.Map<IEnumerable<IDto>>(entities);
        }
    }
}
