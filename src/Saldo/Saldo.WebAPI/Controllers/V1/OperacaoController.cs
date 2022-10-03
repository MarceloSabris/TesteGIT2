using Microsoft.AspNetCore.Mvc;

namespace Transacoes.WebAPI.Controllers.V1
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class OperacaoController
    {   
        
        public OperacaoController (IMediator mediator )
        {

        }

    }
}
