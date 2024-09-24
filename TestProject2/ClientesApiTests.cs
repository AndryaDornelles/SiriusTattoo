using Api.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace SiriusTattoo.Tests
{
    public class ClientesApiTests
    {
        private readonly HttpClient _client;

        public ClientesApiTests()
        {
            // Define a URL base da API
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7154/")
            };

        }
        [Fact]
        public async Task GetClientes_ReturnsOK()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/v1/Clientes");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var clientes = await response.Content.ReadFromJsonAsync<List<ClientesRequest>>();
            Assert.NotNull(clientes);
            Assert.True(clientes.Any());
        }
        [Fact]
        public async Task PostCliente_Cadastrar_ReturnsCreated()
        {
            // Cria um objeto representando o corpo da requisição
            var cliente = new
            {
                id = 0, // O ID é gerado pelo banco, então pode ser 0
                nome = "Cliente de teste",
                email = "clienteteste@gmail.com",
                senha = "1234",
                telefone = "51999999999",
                dataNascimento = "2000-01-01T00:04:22.916Z"
            };

            // Converte o objeto para JSON e cria o conteúdo da requisição
            var jsonContent = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");

            // Faz a requisição POST para cadastrar o cliente
            var response = await _client.PostAsync("https://localhost:7154/api/v1/Clientes/Cadastro", jsonContent);

            // Verifica se a resposta tem status Created (201)
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Verifica se a resposta contém o cliente criado
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseBody);
            var clienteCriado = JsonConvert.DeserializeObject<ClientesRequest>(responseBody);
            Assert.Equal("Cliente de teste", clienteCriado.Nome); // Verifica se o nome corresponde ao enviado
        }
    }
}