using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacao.Application.UseCase.Cliente.PostCliente
{
    public class CreateClienteResult 
    {
        public int Id;
        public int CPF;
        public string Nome;
        public int tipoCliente;
    }
}
