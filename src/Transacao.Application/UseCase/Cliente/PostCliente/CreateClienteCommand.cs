using Transacao.InfraStructure.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;


namespace Transacao.Application.UseCase.Cliente.PostCliente
{
    public class CreateClienteCommand : Request
    {
        public int CPF;
        public string Nome;
        public int tipoCliente;
       
    }

}
