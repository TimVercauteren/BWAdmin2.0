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
    public class OffersController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IOfferRepository _repository;
        private readonly IMapper _mapper;

        public OffersController(ILogger<ClientsController> logger, IOfferRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(IEnumerable<OfferDto>), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet("{clientId}/all")]
        public async Task<IActionResult> GetAll([FromRoute] Guid clientId)
        {
            var result = await _repository.GetAllForClient(clientId);

            return Ok(_mapper.Map<OfferDto>(result));
        }

        // todo :: offerte full dto for pdf Generator
        [ProducesResponseType(typeof(OfferDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _repository.GetEntity<Offer>(id);
            return Ok(MapEntity(result));
        }

        [ProducesResponseType(typeof(OfferDto), 201)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpPost("{clientId}")]
        public async Task<IActionResult> AddOfferForClient([FromBody] OfferDto offer, [FromRoute] Guid clientId)
        {
            var result = await _repository.AddOfferWithItems(_mapper.Map<Offer>(offer), clientId);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, MapEntity(result));
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(OfferDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        public async Task<IActionResult> UpdateClient([FromBody] OfferDto offer, [FromRoute] Guid offerId)
        {
            var result = await _repository.UpdateEntity(offerId, _mapper.Map<PersonInfo>(offer));

            return Ok(MapEntity(result));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            await _repository.DeleteEntity<Offer>(id);

            return Ok();
        }

        private IDto MapEntity(IEntity entity)
        {
            return _mapper.Map<IDto>(entity);
        }

        private IEntity MapData(IDto dataObject)
        {
            return _mapper.Map<IEntity>(dataObject);
        }
    }
}
