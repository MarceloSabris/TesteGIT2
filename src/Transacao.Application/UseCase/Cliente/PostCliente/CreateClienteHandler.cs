using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacao.InfraStructure.Mediator;
using Transacao.InfraStructure.Mediator.Model;

namespace Transacao.Application.UseCase.Cliente.PostCliente
{
    public class CreateClienteHandler : Handler<CreateClienteCommand>
    {
        public override Task<Result> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            return new Result(1);
            
        }
    }
}
