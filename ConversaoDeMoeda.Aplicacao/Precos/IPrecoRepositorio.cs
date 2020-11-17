using ConversaoDeMoeda.Dominio.Precos;

namespace ConversaoDeMoeda.Aplicacao.Precos
{
    public interface IPrecoRepositorio
    {
        Preco ObterPor(string sku);
    }
}
