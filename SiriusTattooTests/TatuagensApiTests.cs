using Api.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace SiriusTattoo.Tests
{
    public class TatuagensApiTests
    {
        private readonly HttpClient _client;

        public TatuagensApiTests()
        {
            // Define a URL base da API
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7154/")
            };
        }
        [Fact]
        public async Task GetTatuagens_ReturnsOK()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Tatuagens/Listar");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var tatuagens = await response.Content.ReadFromJsonAsync<List<TatuagensModel>>();
            Assert.NotNull(tatuagens);
            Assert.True(tatuagens.Any());
        }
        [Fact]
        public async Task GetTatuagens_PorTatuador_ReturnsOk()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Tatuagens/Tatuador/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var tatuagens = await response.Content.ReadFromJsonAsync<List<TatuagensModel>>();
            Assert.NotNull(tatuagens);
            Assert.True(tatuagens.Any());
        }
        [Fact]
        public async Task PostTatuagens_Cadastrar_ReturnsCreated()
        {
            // Cria um objeto representando o corpo da requisição
            var tatuagem = new
            {
                id = 0, // O ID é gerado pelo banco, então pode ser 0
                nome = "Tatuagem de teste",
                descricao = "Descrição da tatuagem de teste",
                preco = 100.50M,
                tatuadorId = 1, // ID de um tatuador existente
                imagem = "imagem_teste.jpg"
            };

            // Converte o objeto para JSON e cria o conteúdo da requisição
            var jsonContent = new StringContent(JsonConvert.SerializeObject(tatuagem), Encoding.UTF8, "application/json");

            // Faz a requisição POST para cadastrar a tatuagem
            var response = await _client.PostAsync("https://localhost:7154/api/Tatuagens/Cadastrar", jsonContent);

            // Verifica se a resposta tem status Created (201)
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Verifica se a resposta contém a tatuagem criada
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseBody); // Garante que há uma resposta
            var tatuagemCriada = JsonConvert.DeserializeObject<TatuagensModel>(responseBody);
            Assert.Equal("Tatuagem de teste", tatuagemCriada.Nome); // Verifica se o nome corresponde ao enviado
        }
    }
}

