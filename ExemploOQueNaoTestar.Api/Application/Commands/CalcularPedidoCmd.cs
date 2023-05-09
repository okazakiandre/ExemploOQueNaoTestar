using MediatR;

namespace ExemploOQueNaoTestar.Api.Application.Commands
{
    internal record CalcularPedidoCmd (
        int NumeroPedido

    ) : IRequest<CalcularPedidoResponse>;
}
