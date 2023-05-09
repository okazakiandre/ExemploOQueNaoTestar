using ExemploOQueNaoTestar.Api.Application.Commands;
using ExemploOQueNaoTestar.Api.Application.Connectors;
using ExemploOQueNaoTestar.Api.Domain;
using ExemploOQueNaoTestar.Api.Infra.Repositories;
using ExemploOQueNaoTestar.Api.Infra.SeedWork;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ExemploOQueNaoTestar.UnitTest
{
    [TestClass]
    [TestCategory("Teste com mocks")]
    public class CalcularPedidoCmdHandlerTest
    {
        [TestMethod]
        public async Task DeveriaRetornarPedidoNaoEncontrado()
        {
            var mockPed = new Mock<IPedidoInput>();
            mockPed.Setup(pi => pi.Obter(It.IsAny<int>())).ReturnsAsync((Pedido)null);
            var mockProd = new Mock<IProdutoInput>();
            var hdl = new CalcularPedidoCmdHandler(mockPed.Object, mockProd.Object);

            var res = await hdl.Handle(new CalcularPedidoCmd(123), CancellationToken.None);

            Assert.IsFalse(res.Sucesso);
            Assert.AreEqual("Pedido não encontrado.", res.Mensagem);
        }

        [TestMethod]
        public async Task DeveriaCalcularValorTotal()
        {
            var ped = new Pedido { NumeroPedido = 123, ValorPedido = 100, ValorFrete = 10 };
            var mockPed = new Mock<IPedidoInput>();
            mockPed.Setup(pi => pi.Obter(It.IsAny<int>())).ReturnsAsync(ped);

            var prod = new Produto { Codigo = 111, ValorFreteMinimo = 101.0};
            var mockProd = new Mock<IProdutoInput>();
            mockProd.Setup(pi => pi.Obter(It.IsAny<int>())).ReturnsAsync(prod);

            var hdl = new CalcularPedidoCmdHandler(mockPed.Object, mockProd.Object);
            var res = await hdl.Handle(new CalcularPedidoCmd(123), CancellationToken.None);

            Assert.IsTrue(res.Sucesso);
            Assert.AreEqual(110.0, res.ValorTotal);
        }
    }
}