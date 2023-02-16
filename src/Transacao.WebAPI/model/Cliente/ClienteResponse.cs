using Transacoes.WebAPI.model.Enum;

namespace Transacoes.WebAPI.model.Cliente
{
    public class ClienteResponse 
    {
        public int idCliente;
        public int CPF;
        public string Nome;
        public TipoCliente tipoCliente;
    }
}
