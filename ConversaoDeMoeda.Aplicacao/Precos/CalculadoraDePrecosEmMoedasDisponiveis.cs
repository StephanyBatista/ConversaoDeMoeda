using System.Collections.Generic;
using ConversaoDeMoeda.Aplicacao.Precos.Moedas;
using ConversaoDeMoeda.Dominio.Precos.Moedas;

namespace ConversaoDeMoeda.Aplicacao.Precos
{
    public class CalculadoraDePrecosEmMoedasDisponiveis
    {
        private readonly IPrecoRepositorio _precoRepositorio;
        private readonly IMoedaRepositorio _moedaRepositorio;

        protected CalculadoraDePrecosEmMoedasDisponiveis() { }
        
        public CalculadoraDePrecosEmMoedasDisponiveis(IPrecoRepositorio precoRepositorio, IMoedaRepositorio moedaRepositorio)
        {
            _precoRepositorio = precoRepositorio;
            _moedaRepositorio = moedaRepositorio;
        }

        public virtual List<PrecoDto> Calcular(string sku)
        {
            var preco = _precoRepositorio.ObterPor(sku);
            var moedas = _moedaRepositorio.ObterTodas();
            var precosConvertidos = new List<PrecoDto>();

            foreach (var moeda in moedas)
            {
                var precoConvertido = moeda.TipoDeCalculo == TipoDeCalculo.Divisao
                    ? preco.ValorBr / moeda.ValorParaConversao
                    : preco.ValorBr * moeda.ValorParaConversao;

                var precoLocal = new PrecoDto { Local = moeda.Local, Valor = precoConvertido };
                precosConvertidos.Add(precoLocal);
            }
            precosConvertidos.Add(new PrecoDto { Local = "Br", Valor = preco.ValorBr });
            return precosConvertidos;
        }
    }
}