using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Transacoes.WebAPI.model;

namespace Transacoes.WebAPI.Controllers.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class ClienteController : ControllerBase
    {
        IMediator _mediator;
        public ClienteController (IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return  Ok();
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> CriarCliente([FromBody] CreateClienteRequest request)
        {

            var result = await _mediator.Send(CreateClienteRequest.CreateClienteCommand(request));
            return Ok();
        }
    }
}
