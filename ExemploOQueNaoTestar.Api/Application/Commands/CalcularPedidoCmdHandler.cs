using ExemploOQueNaoTestar.Api.Application.Connectors;
using MediatR;

namespace ExemploOQueNaoTestar.Api.Application.Commands
{
    internal class CalcularPedidoCmdHandler : IRequestHandler<CalcularPedidoCmd, CalcularPedidoResponse>
    {
        private IPedidoInput PedidoInput { get; }
        private IProdutoInput ProdutoInput { get; }

        public CalcularPedidoCmdHandler(IPedidoInput ped, 
                                        IProdutoInput prod)
        {
            PedidoInput = ped;
            ProdutoInput = prod;
        }

        public async Task<CalcularPedidoResponse> Handle(CalcularPedidoCmd request, CancellationToken cancellationToken)
        {
            var ped = await PedidoInput.Obter(request.NumeroPedido);

            if (ped is null)
            {
                return new CalcularPedidoResponse(0, "Pedido não encontrado.", false);
            }
            else
            {
                var prod = await ProdutoInput.Obter(ped.CodigoProduto);
                var valorTotal = ped.CalcularValorTotal(prod.ValorFreteMinimo);

                return new CalcularPedidoResponse(valorTotal, "", true);
            }
        }
    }
}
