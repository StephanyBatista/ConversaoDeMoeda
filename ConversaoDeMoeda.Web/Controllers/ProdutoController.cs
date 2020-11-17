using Microsoft.AspNetCore.Mvc;
using ConversaoDeMoeda.Aplicacao.Consultas;

namespace ConversaoDeMoeda.Web.Controllers
{
    [ApiController]
    [Route("[controller]/moedas")]
    public class ProdutoController : ControllerBase
    {
        private readonly ConsultaDeProdutoComMoedasDisponiveis _consultaDeProdutoComMoedasDisponiveis;

        public ProdutoController(ConsultaDeProdutoComMoedasDisponiveis consultaDeProdutoComMoedasDisponiveis)
        {
            _consultaDeProdutoComMoedasDisponiveis = consultaDeProdutoComMoedasDisponiveis;
        }

        [HttpGet]
        public ProdutoComPrecosEmMoedasDisponiveisDto Get(string id)
        {
            return _consultaDeProdutoComMoedasDisponiveis.Consultar(id);
        }
    }
}
