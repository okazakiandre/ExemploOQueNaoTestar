namespace ExemploOQueNaoTestar.Api.Application.Commands
{
    public record CalcularPedidoResponse (
        double ValorTotal,
        string Mensagem,
        bool Sucesso
    );
}
