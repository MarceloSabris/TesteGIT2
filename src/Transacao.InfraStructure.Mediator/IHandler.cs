using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.InfraStructure.Mediator
{
    public interface IHandler<in TRequest> : IRequestHandler<TRequest, IResult>
      where TRequest : IRequest
    {
    }

  
}
