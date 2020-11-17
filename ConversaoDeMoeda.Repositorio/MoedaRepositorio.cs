using System.Collections.Generic;
using ConversaoDeMoeda.Aplicacao.Precos.Moedas;
using ConversaoDeMoeda.Dominio.Precos.Moedas;

namespace ConversaoDeMoeda.Repositorio
{
    public class MoedaRepositorio : IMoedaRepositorio
    {
        public List<Moeda> ObterTodas()
        {
            var us = new Moeda("US", 5.35, TipoDeCalculo.Divisao);
            var europe = new Moeda("Euro", 5.80, TipoDeCalculo.Divisao);
            var indian = new Moeda("Indian", 13.73, TipoDeCalculo.Multiplicacao);
            return new List<Moeda> {us, europe, indian};
        }
    }
}
