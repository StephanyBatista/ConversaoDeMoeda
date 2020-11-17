namespace ConversaoDeMoeda.Dominio.Produtos
{
    public class Produto
    {
        public string Sku { get; }
        public string Nome { get; }
        public string Descricao { get; }
        public string CaminhoDaImagem { get; }

        public Produto(string sku, string nome, string descricao, string caminhoDaImagem)
        {
            Sku = sku;
            Nome = nome;
            Descricao = descricao;
            CaminhoDaImagem = caminhoDaImagem;
        }
    }
}
