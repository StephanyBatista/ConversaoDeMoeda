using System.Collections.Generic;
using ConversaoDeMoeda.Dominio.Precos.Moedas;

namespace ConversaoDeMoeda.Aplicacao.Precos.Moedas
{
    public interface IMoedaRepositorio
    {
        List<Moeda> ObterTodas();
    }
}
