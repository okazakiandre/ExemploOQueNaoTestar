using ExemploOQueNaoTestar.Api.Application.Connectors;
using ExemploOQueNaoTestar.Api.Domain;

namespace ExemploOQueNaoTestar.Api.Infra
{
    public class ProdutoApiClient : IProdutoInput
    {
        public async Task<Produto> Obter(int codigoProduto)
        {
            var http = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5149/")
            };
            var resp = await http.GetFromJsonAsync<Produto>($"produtos/{codigoProduto}");
            return resp;
        }
    }
}