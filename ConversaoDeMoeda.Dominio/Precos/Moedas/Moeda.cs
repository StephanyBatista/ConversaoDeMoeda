namespace ConversaoDeMoeda.Dominio.Precos.Moedas
{
    public enum TipoDeCalculo
    {
        Divisao,
        Multiplicacao
    }
    
    public class Moeda
    {
        public string Local { get; }
        public double ValorParaConversao { get; }
        public TipoDeCalculo TipoDeCalculo { get; }

        public Moeda(string local, double valorParaConversao, TipoDeCalculo tipoDeCalculo)
        {
            Local = local;
            ValorParaConversao = valorParaConversao;
            TipoDeCalculo = tipoDeCalculo;
        }
    }
}
