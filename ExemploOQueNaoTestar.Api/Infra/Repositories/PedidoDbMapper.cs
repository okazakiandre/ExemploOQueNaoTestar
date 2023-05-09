using ExemploOQueNaoTestar.Api.Domain;
using MongoDB.Bson.Serialization;

namespace ExemploOQueNaoTestar.Api.Infra.Repositories
{
    public class PedidoDbMapper : BsonClassMap<Pedido>
    {
        public PedidoDbMapper()
        {
            AutoMap();
            SetIgnoreExtraElements(true);

            MapIdMember(m => m.NumeroPedido);
        }
    }
}
