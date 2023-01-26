using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.InfraStructure.Mediator
{
    public interface IRequest : MediatR.IRequest<IResult>
    {

    }
   
}
