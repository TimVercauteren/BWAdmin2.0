using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BWAdminUi.Server.Repositories.Interfaces;
using BWAdminUi.Server.Setup;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Read;

namespace BWAdminUi.Server.Controllers.Business
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _repository;

        public UsersController(ILogger<UsersController> logger, IUserRepository repository, IMapper mapper, IInfoRepository infoRepository)
        {
            _logger = logger;
            _repository = repository;
        }

        [ProducesResponseType(typeof(UserWithInfoDto), 200)]
        [ProducesDefaultResponseType(typeof(ApiError))]
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IHttpContextAccessor contextAccessor)
        {
            var userId = contextAccessor.HttpContext.User.Claims;

            var result = await _repository.GetUserWithInfo("userId");
            return Ok(result);
        }
    }
}
