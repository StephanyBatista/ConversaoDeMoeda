using ConversaoDeMoeda.Aplicacao.Precos;
using ConversaoDeMoeda.Aplicacao.Produtos;

namespace ConversaoDeMoeda.Aplicacao.Consultas
{
    public class ConsultaDeProdutoComMoedasDisponiveis
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly CalculadoraDePrecosEmMoedasDisponiveis _calculadoraDePrecosEmMoedasDisponiveis;

        public ConsultaDeProdutoComMoedasDisponiveis(
            IProdutoRepositorio produtoRepositorio, 
            CalculadoraDePrecosEmMoedasDisponiveis calculadoraDePrecosEmMoedasDisponiveis)
        {
            _produtoRepositorio = produtoRepositorio;
            _calculadoraDePrecosEmMoedasDisponiveis = calculadoraDePrecosEmMoedasDisponiveis;
        }

        public ProdutoComPrecosEmMoedasDisponiveisDto Consultar(string sku)
        {
            var produto = _produtoRepositorio.ObterPor(sku);

            var produtoComMoedasDto = new ProdutoComPrecosEmMoedasDisponiveisDto
            {
                Nome = produto.Nome,
                Sku = produto.Sku
            };

            var precosEmMoedasDisponiveis = _calculadoraDePrecosEmMoedasDisponiveis.Calcular(sku);
            foreach (var preco in precosEmMoedasDisponiveis)
            {
                produtoComMoedasDto.AdicionarMoeda(preco);
            }

            return produtoComMoedasDto;
        }
    }
}