namespace ConversaoDeMoeda.Dominio.Precos
{
    public class Preco
    {
        public string Sku { get; }
        public double ValorBr { get; }
        public int DivideEm { get; }

        public Preco(string sku, double valorBr, int divideEm)
        {
            Sku = sku;
            ValorBr = valorBr;
            DivideEm = divideEm;
        }
    }
}
