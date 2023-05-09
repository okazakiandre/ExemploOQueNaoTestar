using ExemploOQueNaoTestar.Api.Domain;

namespace ExemploOQueNaoTestar.UnitTest
{
    [TestClass]
    [TestCategory("Teste de código")]
    public class PedidoTesteCodigoTest
    {
        [TestMethod]
        public void DeveriaCalcularValorTotalComFrete()
        {
            var pedido = new Pedido
            {
                ValorPedido = 100,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = false }
            };
            var valorMinimoFreteGratis = 150;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(110, valorTotal);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalSemFreteSeValorPedidoMaiorQueOMinimo()
        {
            var pedido = new Pedido
            {
                ValorPedido = 200,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = false }
            };
            var valorMinimoFreteGratis = 150;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(200, valorTotal);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalSemFreteSeValorPedidoIgualAoMinimo()
        {
            var pedido = new Pedido
            {
                ValorPedido = 150,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = false }
            };
            var valorMinimoFreteGratis = 150;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(150, valorTotal);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalSemFreteParaClienteVip()
        {
            var pedido = new Pedido
            {
                ValorPedido = 100,
                ValorFrete = 10,
                Cliente = new Cliente { IndicadorVip = true }
            };
            var valorMinimoFreteGratis = 150;

            var valorTotal = pedido.CalcularValorTotal(valorMinimoFreteGratis);

            Assert.AreEqual(100, valorTotal);
        }
    }
}