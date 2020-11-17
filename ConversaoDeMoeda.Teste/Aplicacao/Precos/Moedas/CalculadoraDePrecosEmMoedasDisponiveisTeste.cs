using System.Collections.Generic;
using ConversaoDeMoeda.Aplicacao.Precos;
using ConversaoDeMoeda.Aplicacao.Precos.Moedas;
using ConversaoDeMoeda.Dominio.Precos;
using ConversaoDeMoeda.Dominio.Precos.Moedas;
using ExpectedObjects;
using Moq;
using Xunit;

namespace ConversaoDeMoeda.Teste.Aplicacao.Precos.Moedas
{
    public class CalculadoraDePrecosEmMoedasDisponiveisTeste
    {
        private const string Sku = "#12";
        private readonly CalculadoraDePrecosEmMoedasDisponiveis _calculadoraDePrecosEmMoedasDisponiveis;

        public CalculadoraDePrecosEmMoedasDisponiveisTeste()
        {
            var preco = new Preco(Sku, 579.89, 12);
            var precoRepositorio = new Mock<IPrecoRepositorio>();
            precoRepositorio.Setup(r => r.ObterPor(preco.Sku)).Returns(preco);

            var us = new Moeda("US", 5.35, TipoDeCalculo.Divisao);
            var europe = new Moeda("Euro", 5.80, TipoDeCalculo.Divisao);
            var indian = new Moeda("Indian", 13.73, TipoDeCalculo.Multiplicacao);
            var moedaRepositorio = new Mock<IMoedaRepositorio>();
            moedaRepositorio.Setup(r => r.ObterTodas()).Returns(new List<Moeda> { us, europe, indian });

            _calculadoraDePrecosEmMoedasDisponiveis = new CalculadoraDePrecosEmMoedasDisponiveis(precoRepositorio.Object, moedaRepositorio.Object);
        }

        [Fact]
        public void DeveConverterPrecoDeUmProdutoParaMoedasDisponiveis()
        {
            var precosEsperados = new[]
            {
                new {Local = "US", Valor = 108.39065420560748},
                new {Local = "Euro", Valor = 99.981034482758616},
                new {Local = "Indian", Valor = 7961.8897},
                new {Local = "Br", Valor = 579.89}
            };
            
            var precosEmMoedasDisponiveis = _calculadoraDePrecosEmMoedasDisponiveis.Calcular(Sku);

            precosEsperados.ToExpectedObject().ShouldMatch(precosEmMoedasDisponiveis);
        }

        [Fact]
        public void DeveRetornarTambemOPrecoEmBrSemConversao()
        {
            var precoEsperado = new {Local = "Br", Valor = 579.89};

            var precosEmMoedasDisponiveis = _calculadoraDePrecosEmMoedasDisponiveis.Calcular(Sku);

            precoEsperado.ToExpectedObject().ShouldMatch(precosEmMoedasDisponiveis[3]);
        }
    }
}
