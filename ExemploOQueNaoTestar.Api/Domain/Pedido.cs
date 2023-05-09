namespace ExemploOQueNaoTestar.Api.Domain
{
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public int CodigoProduto { get; set; }
        public double ValorPedido { get; set; }
        public double ValorFrete { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();

        public double CalcularValorTotal(double valorMinimoFreteGratis)
        {
            var valorTotal = ValorPedido + ValorFrete;
            if (ValorPedido >= valorMinimoFreteGratis &&
                Cliente.IndicadorVip)
            {
                valorTotal = ValorPedido;
            }
            return valorTotal;
        }
    }
}