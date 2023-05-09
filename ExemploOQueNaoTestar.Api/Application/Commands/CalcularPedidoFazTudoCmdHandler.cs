using ExemploOQueNaoTestar.Api.Domain;
using ExemploOQueNaoTestar.Api.Infra.SeedWork;
using MediatR;
using MongoDB.Driver;

namespace ExemploOQueNaoTestar.Api.Application.Commands
{
    internal class CalcularPedidoFazTudoCmdHandler : IRequestHandler<CalcularPedidoCmd, CalcularPedidoResponse>
    {
        private IMongoDbContext DbCtx { get; }

        public CalcularPedidoFazTudoCmdHandler(IMongoDbContext db)
        {
            DbCtx = db;
        }

        public async Task<CalcularPedidoResponse> Handle(CalcularPedidoCmd request, CancellationToken cancellationToken)
        {
            var pedCol = DbCtx.GetCollection<Pedido>("Pedido");
            var pedColRes = await pedCol.FindAsync(p => p.NumeroPedido == request.NumeroPedido, cancellationToken: cancellationToken);
            var ped = await pedColRes.FirstOrDefaultAsync(cancellationToken);

            if (ped is null)
            {
                return new CalcularPedidoResponse(0, "Pedido não encontrado.", false);
            }
            else
            {
                var http = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:5149")
                };
                var prod = await http.GetFromJsonAsync<Produto>($"/produtos/{ped.CodigoProduto}", cancellationToken: cancellationToken);

                var valorTotal = ped.CalcularValorTotal(prod.ValorFreteMinimo);

                return new CalcularPedidoResponse(valorTotal, "", true);
            }
        }
    }
}
