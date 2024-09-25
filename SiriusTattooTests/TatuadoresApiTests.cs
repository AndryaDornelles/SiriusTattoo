using Api.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace SiriusTattoo.Tests
{
    public class TatuadoresApiTests
    {
        private readonly HttpClient _client;

        public TatuadoresApiTests()
        {
            // Define a URL base da API
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7154/")
            };
        }
        [Fact]
        public async Task GetTatuadores_ReturnsOk()
        {
            // Act: Faz a requisição GET ao endpoint da API real
            var response = await _client.GetAsync("api/v1/Tatuadores");

            // Assert: Verifica se a resposta retorna o código de sucesso
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Verifica se os dados retornados são válidos
            var tatuadores = await response.Content.ReadFromJsonAsync<List<TatuadoresModel>>();
            Assert.NotNull(tatuadores); // Garante que os dados não são nulos
            Assert.True(tatuadores.Count > 0); // Verifica que ao menos um tatuador foi retornado
        }
        [Fact]
        public async Task PostTatuador_Cadastrar_ReturnsCreated()
        {
            // Cria um objeto representando o corpo da requisição
            var tatuador = new
            {
                id = 0, // O ID é gerado pelo banco, então pode ser 0
                nome = "Tatuador de teste",
                email = "tatuadorteste@hotmail.com",
                senha = "12345",
                telefone = "51999999999",
                especialidade = "FineLine"
            };

            // Converte o objeto para JSON e cria o conteúdo da requisição
            var jsonContent = new StringContent(JsonConvert.SerializeObject(tatuador), Encoding.UTF8, "application/json");

            // Faz a requisição POST para cadastrar o tatuador
            var response = await _client.PostAsync("https://localhost:7154/api/v1/Tatuadores/Cadastro", jsonContent);

            // Verifica se a resposta tem status Created (201)
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Verifica se a resposta contém o tatuador criado
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseBody);
            var tatuadorCriado = JsonConvert.DeserializeObject<ClientesRequest>(responseBody);
            Assert.Equal("Tatuador de teste", tatuadorCriado.Nome); // Verifica se o nome corresponde ao enviado
        }

    }
}
