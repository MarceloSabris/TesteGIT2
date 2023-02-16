using System.ComponentModel.DataAnnotations;
using Transacao.Application.UseCase.Cliente.PostCliente;
using Transacoes.WebAPI.model.Enum;

namespace Transacoes.WebAPI.model
{
    // Como se trata de um teste fiz o onboarding do cliente no mesmo microserviço
    public class CreateClienteRequest
    {
        [Required]
        public int CPF;
        [Required]
        public string Nome;
        [Required]
        public TipoCliente tipoCliente;

        public static CreateClienteCommand CreateClienteCommand(CreateClienteRequest cliente)
        {
            return new CreateClienteCommand() { CPF = cliente.CPF, Nome = cliente.Nome, tipoCliente = (int)cliente.tipoCliente };
        }

    }
}
