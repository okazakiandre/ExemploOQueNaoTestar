using ExemploOQueNaoTestar.Api.Domain;
using ExemploOQueNaoTestar.Api.Infra.SeedWork;
using MongoDB.Driver;

namespace ExemploOQueNaoTestar.Api.Infra.Repositories
{
    public class PedidoDbContext : MongoDbContextBase, IMongoDbContext
    {
        public PedidoDbContext(IConfiguration config) : base(config)
        {
            OnRegisterMappers();
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Database.GetCollection<T>(collectionName);
        }

        protected override void OnRegisterMappers()
        {
            RegisterClassMap<Pedido, PedidoDbMapper>();
        }

    }
}
