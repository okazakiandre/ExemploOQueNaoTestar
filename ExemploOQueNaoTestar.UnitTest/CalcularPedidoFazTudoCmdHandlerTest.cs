using ExemploOQueNaoTestar.Api.Application.Commands;
using ExemploOQueNaoTestar.Api.Infra.Repositories;
using ExemploOQueNaoTestar.Api.Infra.SeedWork;
using Microsoft.Extensions.Configuration;

namespace ExemploOQueNaoTestar.UnitTest
{
    [TestClass]
    [TestCategory("Teste com acesso a rede e ao disco")]
    public class CalcularPedidoFazTudoCmdHandlerTest
    {
        private IMongoDbContext _dbCtx;
        private CalcularPedidoFazTudoCmdHandler _hdl;

        [TestInitialize]
        public void Init()
        {
            var cfgBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _dbCtx = new PedidoDbContext(cfgBuilder.Build());

            _hdl = new CalcularPedidoFazTudoCmdHandler(_dbCtx);
        }

        [TestMethod]
        public async Task DeveriaRetornarPedidoNaoEncontrado()
        {
            var cmd = new CalcularPedidoCmd(0);

            var result = await _hdl.Handle(cmd, new CancellationToken());

            Assert.IsFalse(result.Sucesso);
            Assert.AreEqual("Pedido não encontrado.", result.Mensagem);
            Assert.AreEqual(0, result.ValorTotal);
        }

        [TestMethod]
        public async Task DeveriaCalcularValorTotal()
        {
            var cmd = new CalcularPedidoCmd(555);

            var result = await _hdl.Handle(cmd, new CancellationToken());

            Assert.IsTrue(result.Sucesso);
            Assert.AreEqual(150, result.ValorTotal);
        }
    }
}
