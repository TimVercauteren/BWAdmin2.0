using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Post;

namespace BWAdmin2._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientsController(ILogger<ClientsController> logger, IClientRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(IEnumerable<Client>), 200)]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();

            return Ok(result);
        }

        [ProducesResponseType(typeof(Client), 200)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _repository.GetClient(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ClientDto), 201)]
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientDto clientDto)
        {
            var result = await _repository.AddClient(clientDto);

            return CreatedAtAction(nameof(Get), new {id = result.Id}, _mapper.Map<ClientDto>(result));
        }
    }
}
