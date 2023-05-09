using ExemploOQueNaoTestar.Api.Domain;

namespace ExemploOQueNaoTestar.UnitTest
{
    [TestClass]
    [TestCategory("Teste de requisito")]
    public class PedidoTesteRequisitoTest
    {
        /*
         * REQUISITO:
         * - O valor total é o valor do pedido + o valor do frete.
         * - O cliente VIP tem direito a frete grátis em pedidos a partir de R$ 100.
         */

        [TestMethod]
        public void DeveriaCalcularValorTotalSemFreteParaClienteVipEPedidoAcimaDoMinimo()
        {
            var pedido = new Pedido
            {
                ValorPedido = 101,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = true }
            };
            var valorMinimoFreteGratis = 100;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(101, valorTotal);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalSemFreteParaClienteVipEPedidoIgualAoMinimo()
        {
            var pedido = new Pedido
            {
                ValorPedido = 100,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = true }
            };
            var valorMinimoFreteGratis = 100;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(100, valorTotal);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalComFreteParaClienteVipEPedidoAbaixoDoMinimo()
        {
            var pedido = new Pedido
            {
                ValorPedido = 99,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = true }
            };
            var valorMinimoFreteGratis = 100;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(109, valorTotal);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalComFreteParaClienteNaoVip()
        {
            var pedido = new Pedido
            {
                ValorPedido = 101,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = false }
            };
            var valorMinimoFreteGratis = 100;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(111, valorTotal);
        }
    }
}