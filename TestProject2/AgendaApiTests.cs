using Api.Models;
using Azure.Core;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SiriusTattoo.Tests
{
    public class AgendaApiTests
    {
        private readonly HttpClient _client;

        public AgendaApiTests()
        {
            // Define a URL base da API
            _client = new HttpClient
            {
                BaseAddress = new System.Uri("https://localhost:7154/")
            };
        }

        [Fact]
        public async Task GetAgenda_ReturnsOk()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Agenda/Listar");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var agenda = await response.Content.ReadFromJsonAsync<List<AgendaRequest>>();
            Assert.NotNull(agenda);
            Assert.True(agenda.Count > 0);
        }
        [Fact]
        public async Task GetAgenda_PorCliente_ReturnsOK()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Agenda/Cliente/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var agenda = await response.Content.ReadFromJsonAsync<List<AgendaRequest>>();
            Assert.NotNull(agenda);
            Assert.True(agenda.Any());
        }
        [Fact]
        public async Task GetAgenda_PorTatuador_ReturnsOk()
        {
            var response = await _client.GetAsync("https://localhost:7154/api/Agenda/Tatuador/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var agenda = await response.Content.ReadFromJsonAsync<List<AgendaRequest>>();
            Assert.NotNull(agenda);
            Assert.True(agenda.Any());
        }
        [Fact]
        public async Task PostAgenda_Agendar_ReturnsCreated()
        {
            // Cria um objeto representando o corpo da requisição
            var agenda = new
            {
                clienteId = 1,
                tatuadorId = 1, 
                dataSessao = "2024-10-23T23:45:11.785Z30", 
                status = "Agendado"
            };

            // Converte o objeto para JSON e cria o conteúdo da requisição
            var jsonContent = new StringContent(JsonConvert.SerializeObject(agenda), Encoding.UTF8, "application/json");

            // Faz a requisição POST para cadastrar a agenda
            var response = await _client.PostAsync("api/Agenda/Agendar", jsonContent);

            // Verifica se a resposta contém o agendamento criado
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.NotNull(responseBody); // Garante que há uma resposta
            Console.WriteLine(responseBody); // Para ver o conteúdo da resposta
        }

    }

}



