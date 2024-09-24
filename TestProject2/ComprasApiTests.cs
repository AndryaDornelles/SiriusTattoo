using Api.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace SiriusTattoo.Tests
{
    public class ComprasApiTests
    {
        private readonly HttpClient _client;

        public ComprasApiTests()
        {
            // Define a URL base da API
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7154/")
            };
        }
        [Fact]
        public async Task GetCompras_ReturnsOK()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Compras/Listar");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var compras = await response.Content.ReadFromJsonAsync<List<ComprasRequest>>();
            Assert.NotNull(compras);
            Assert.True(compras.Any());
        }
        [Fact]
        public async Task GetCompras_PorTatuador()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Compras/Tatuador/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var compras = await response.Content.ReadFromJsonAsync<List<AgendaRequest>>();
            Assert.NotNull(compras);
            Assert.True(compras.Any());
        }
        [Fact]
        public async Task GetCompras_PorCliente()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Compras/Cliente/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var Cliente = await response.Content.ReadFromJsonAsync<List<AgendaRequest>>();
            Assert.NotNull(Cliente);
            Assert.True(Cliente.Any());
        }
        [Fact]
        public async Task PostCompras_Compras()
        {
            var compra = new
            {
                clienteId = 1,
                tatuagemId = 7,
            };

            // Converte o objeto para JSON e cria o conteúdo da requisição
            var jsonContent = new StringContent(JsonConvert.SerializeObject(compra), Encoding.UTF8, "application/json");

            // Faz a requisição POST para cadastrar a compra
            var response = await _client.PostAsync("https://localhost:7154/api/Compras/Comprar", jsonContent);

            // Verifica se a resposta tem status Ok (200)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Verifica se a resposta contém a compra criada
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseBody); // Garante que há uma resposta
        }
    }
}
