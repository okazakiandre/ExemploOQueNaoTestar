using ExemploOQueNaoTestar.Api.Application.Connectors;
using ExemploOQueNaoTestar.Api.Domain;
using ExemploOQueNaoTestar.Api.Infra.SeedWork;
using MongoDB.Driver;

namespace ExemploOQueNaoTestar.Api.Infra.Repositories
{
    public class PedidoRepository : IPedidoInput
    {
        private IMongoCollection<Pedido> PedCol { get; }

        public PedidoRepository(IMongoDbContext db)
        {
            PedCol = db.GetCollection<Pedido>("Pedido");
        }

        public async Task<Pedido> Obter(int numeroPedido)
        {
            var res = await PedCol.FindAsync(p => p.NumeroPedido == numeroPedido);
            return await res.FirstOrDefaultAsync();
        }
    }
}
