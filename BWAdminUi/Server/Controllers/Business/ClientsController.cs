using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BWAdminUi.Server.Repositories.Interfaces;
using BWAdminUi.Server.Setup;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Post;
using Models.Read;
using ClientEntity = Data.Entities.Client;

namespace BWAdminUi.Server.Controllers.Business
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        private readonly IInfoRepository _infoRepository;

        public ClientsController(ILogger<ClientsController> logger, IClientRepository repository, IMapper mapper, IInfoRepository infoRepository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _infoRepository = infoRepository;
        }

        [ProducesResponseType(typeof(IEnumerable<ClientDto>), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();

            return Ok(result);
        }

        [ProducesResponseType(typeof(ClientDetailDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _repository.GetClient(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(ClientDto), 201)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientDto client, [FromServices] UserManager<ApplicationUser> userManager)
        {
            var user = this.User;
            var userId = userManager.GetUserId(user);

            var result = await _repository.AddClient(_mapper.Map<ClientEntity>(client), userId);

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
            await _repository.DeleteEntity<ClientEntity>(id);

            return Ok();
        }
    }
}
