using System.Collections.Generic;
using ConversaoDeMoeda.Aplicacao.Consultas;
using ConversaoDeMoeda.Aplicacao.Precos;
using ConversaoDeMoeda.Aplicacao.Produtos;
using ConversaoDeMoeda.Dominio.Produtos;
using ExpectedObjects;
using Moq;
using Xunit;

namespace ConversaoDeMoeda.Teste.Aplicacao.Consultas
{
    public class ConsultaDeProdutoComMoedasDisponiveisTeste
    {
        private const string Sku = "#12";
        private readonly Produto _produto;
        private readonly List<PrecoDto> _precosEmMoedasDisponiveis;
        private readonly Mock<IProdutoRepositorio> _produtoRepositorio;
        private readonly ConsultaDeProdutoComMoedasDisponiveis _consultaDeProdutoComMoedasDisponiveis;
        private readonly Mock<CalculadoraDePrecosEmMoedasDisponiveis> _calculadoraDePrecosEmMoedasDisponiveis;

        public ConsultaDeProdutoComMoedasDisponiveisTeste()
        {
            _produto = new Produto(Sku, "Tenis Nike Nasa Wear", "Um tênis bala", "http://centauro.com.br/#12/foto.png");
            _produtoRepositorio = new Mock<IProdutoRepositorio>();
            _produtoRepositorio.Setup(r => r.ObterPor(_produto.Sku)).Returns(_produto);

            _precosEmMoedasDisponiveis = new List<PrecoDto>
            {
                new PrecoDto {Local = "US", Valor = 98},
                new PrecoDto {Local = "Br", Valor = 98},
            };
            _calculadoraDePrecosEmMoedasDisponiveis = new Mock<CalculadoraDePrecosEmMoedasDisponiveis>();
            _calculadoraDePrecosEmMoedasDisponiveis.Setup(c => c.Calcular(Sku)).Returns(_precosEmMoedasDisponiveis);

            _consultaDeProdutoComMoedasDisponiveis = 
                new ConsultaDeProdutoComMoedasDisponiveis(_produtoRepositorio.Object, _calculadoraDePrecosEmMoedasDisponiveis.Object);
        }

        [Fact]
        public void DeveConsultarProdutoAtravesDoRepositorio()
        {
            _consultaDeProdutoComMoedasDisponiveis.Consultar(Sku);

            _produtoRepositorio.Verify(r => r.ObterPor(Sku));
        }

        [Fact]
        public void DeveConsultarCalculadoraParaRetornarPrecosDisponiveisEmMoedas()
        {
            _consultaDeProdutoComMoedasDisponiveis.Consultar(Sku);

            _calculadoraDePrecosEmMoedasDisponiveis.Verify(c => c.Calcular(Sku));
        }

        [Fact]
        public void DeveConsultarProdutoComSeusPrecos()
        {
            var produtoEsperado = new ProdutoComPrecosEmMoedasDisponiveisDto
            {
                Sku = _produto.Sku,
                Nome = _produto.Nome,
                Precos = _precosEmMoedasDisponiveis
            };
            
            var produto = _consultaDeProdutoComMoedasDisponiveis.Consultar(Sku);

            produtoEsperado.ToExpectedObject().ShouldMatch(produto);
        }
    }
}
