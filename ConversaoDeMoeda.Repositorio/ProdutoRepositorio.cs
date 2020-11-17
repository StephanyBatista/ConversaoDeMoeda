using ConversaoDeMoeda.Aplicacao.Produtos;
using ConversaoDeMoeda.Dominio.Produtos;

namespace ConversaoDeMoeda.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public Produto ObterPor(string sku)
        {
            return new Produto(sku, "Tenis Nike Nasa Wear", "Um tênis bala", "http://centauro.com.br/#12/foto.png");
        }
    }
}
