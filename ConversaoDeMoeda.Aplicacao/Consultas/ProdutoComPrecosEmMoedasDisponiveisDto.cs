using System.Collections.Generic;
using ConversaoDeMoeda.Aplicacao.Precos;

namespace ConversaoDeMoeda.Aplicacao.Consultas
{
    public class ProdutoComPrecosEmMoedasDisponiveisDto
    {
        public string Sku { get; set; }
        public string Nome { get; set; }
        public List<PrecoDto> Precos { get; set; }

        public void AdicionarMoeda(PrecoDto preco)
        {
            Precos ??= new List<PrecoDto>();

            Precos.Add(preco);
        }
    }
}