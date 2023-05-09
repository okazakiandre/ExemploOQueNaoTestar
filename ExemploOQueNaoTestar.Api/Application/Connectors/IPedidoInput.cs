using ExemploOQueNaoTestar.Api.Domain;

namespace ExemploOQueNaoTestar.Api.Application.Connectors
{
    public interface IPedidoInput
    {
        public Task<Pedido> Obter(int numeroPedido);
    }
}
