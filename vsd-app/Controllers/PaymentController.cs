using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Manager.Contract;
using MediatR;
using System.Threading.Tasks;

namespace Gov.Cscp.VictimServices.Public.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly IMediator _mediator;

        public PaymentController(ILogger<ConfigurationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("send")]
        public async Task<IActionResult> SendPaymentsToCas()
        {
            var command = new SendPaymentsToCasCommand();
            var isSuccessful = await _mediator.Send(command);
            return Ok(isSuccessful);
        }
    }
}
