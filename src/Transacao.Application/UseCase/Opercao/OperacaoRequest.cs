using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transacao.Application.UseCase.Enum;

namespace Transacao.Application.UseCase
{
    public class OperacaoRequest
    {
        public decimal Valor { get; set; }
        public TipoLancamentoRequest TipoLancamento { get; set; }
        //poderia teter um cadastro de origem , como se trata de um teste
        // simplifiquei como string 
        public string Origem { get; set; }

        public int idCliente { get; set; }
    }


}
