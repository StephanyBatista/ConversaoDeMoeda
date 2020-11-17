using ConversaoDeMoeda.Dominio.Produtos;

namespace ConversaoDeMoeda.Aplicacao.Produtos
{
    public interface IProdutoRepositorio
    {
        Produto ObterPor(string sku);
    }
}
