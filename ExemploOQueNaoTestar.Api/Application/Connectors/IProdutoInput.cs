using ExemploOQueNaoTestar.Api.Domain;

namespace ExemploOQueNaoTestar.Api.Application.Connectors
{
    public interface IProdutoInput
    {
        public Task<Produto> Obter(int codigoProduto);
    }
}
