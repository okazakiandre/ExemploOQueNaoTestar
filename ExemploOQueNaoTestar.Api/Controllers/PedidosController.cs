using ExemploOQueNaoTestar.Api.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExemploOQueNaoTestar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private IMediator Mdtr { get; }

        public PedidosController(IMediator mdt)
        {
            Mdtr = mdt;
        }

        [HttpGet("{numeroPedido}")]
        public async Task<IActionResult> ObterValorTotal(int numeroPedido)
        {
            var req = new CalcularPedidoCmd(numeroPedido);
            var res = await Mdtr.Send(req);
            return Ok(res);
        }
    }
}