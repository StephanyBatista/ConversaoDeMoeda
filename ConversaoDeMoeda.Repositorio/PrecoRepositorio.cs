using ConversaoDeMoeda.Aplicacao.Precos;
using ConversaoDeMoeda.Dominio.Precos;

namespace ConversaoDeMoeda.Repositorio
{
    public class PrecoRepositorio : IPrecoRepositorio
    {
        public Preco ObterPor(string sku)
        {
            return new Preco(sku, 579.89, 12);
        }
    }
}
