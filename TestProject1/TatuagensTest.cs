using Tatuadores;
namespace TestProject1
{
    using RestSharp;
    using Xunit;
    using System.Net;
    using Tatuadores;
    public class TatuagensTest
    {
        private readonly RestClient _client;
        
        public TatuagensTest()
        {
            _client = new RestClient("https://localhost:7154/api/Tatuagens/Tatuador/");
        }

        [Fact]
        public void BuscarPorTatuador()
        {
            var request = new RestRequest("Tatuador/1", Method.Get);

            var response = _client.Execute<Tatuagens>(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Data);
            Assert.Equal(3, response.Data.Id);
            Assert.Equal("Poção do Amor", response.Data.Nome);
            Assert.Equal("tatuagem de 14cm com um coração dentro de um frasco de poção", response.Data.Descricao);
            Assert.Equal("1", response.Data.TatuadorId);
            Assert.Equal("300", response.Data.Preco);
        }
    }
}