namespace Transacoes.WebAPI.model
{
    public class Operacao
    {
        //identificador do cliente usado como int pois não sei o tamanho da base 
        public int idCliente { get; set; }

        public decimal Valor { get; set; }
        public TipoLancamento YipoLancamento { get; set; }
        //poderia teter um cadastro de origem , como se trata de um teste
        // simplifiquei como string 
        public string Origem { get; set; }
    }
}
