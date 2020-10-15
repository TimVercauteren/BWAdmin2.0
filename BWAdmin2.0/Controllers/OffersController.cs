using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BWAdmin2._0.Setup;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.Post;
using Models.Read;

namespace BWAdmin2._0.Controllers
{
    [ApiController]
    [Route("[controller]/{clientId}")]
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
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromRoute] Guid clientId)
        {
            var result = await _repository.GetAllForClient(clientId);

            return Ok(_mapper.Map<OfferDto>(result));
        }

        [ProducesResponseType(typeof(OfferDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _repository.GetEntity<Offer>(id);
            return Ok(MapEntity(result));
        }

        [ProducesResponseType(typeof(ClientDto), 201)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientDto client)
        {

            var result = await _repository.AddClient(_mapper.Map<Client>(client));

            return CreatedAtAction(nameof(Get), new { id = result.Id }, _mapper.Map<ClientDto>(result));
        }

        [HttpPut("{infoId}")]
        [ProducesResponseType(typeof(PersonInfoDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        public async Task<IActionResult> UpdateClient([FromBody] PersonInfoDto clientInfo, [FromRoute] Guid infoId)
        {
            var result = await _infoRepository.UpdateEntity(infoId, _mapper.Map<PersonInfo>(clientInfo));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        public async Task<IActionResult> DeleteClient([FromRoute] Guid id)
        {
            await _repository.DeleteEntity<Client>(id);

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
