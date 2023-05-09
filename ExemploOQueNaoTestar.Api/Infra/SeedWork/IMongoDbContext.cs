using MongoDB.Driver;

namespace ExemploOQueNaoTestar.Api.Infra.SeedWork
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
