﻿using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ExemploOQueNaoTestar.Api.Infra.SeedWork
{
    public abstract class MongoDbContextBase
    {
        public IMongoDatabase Database { get; }
        protected MongoDbContextBase(IConfiguration config)
        {
            string cn = config.GetSection("mongoDb")["connectionString"];
            var settings = MongoClientSettings.FromUrl(new MongoUrl(cn));
            var mc = new MongoClient(settings);
            Database = mc.GetDatabase(new MongoUrl(cn).DatabaseName);
        }

        protected abstract void OnRegisterMappers();

        protected virtual void RegisterClassMap<Entity, Mapper>() where Mapper : BsonClassMap<Entity>, new()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap(new Mapper());
            }
        }
    }
}
