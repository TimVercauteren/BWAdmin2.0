using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
