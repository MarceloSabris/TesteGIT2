using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.InfraStructure.Mediator
{
    public interface IHandlerMiddleware<in TRequest> : IPipelineBehavior<TRequest, IResult>
      where TRequest : IRequest
    {
    }
}