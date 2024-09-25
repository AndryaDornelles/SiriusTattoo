using System.Text.Json.Serialization;

namespace Api.Models
{
    public class TatuagensModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public long TatuadorId { get; set; }
        public string? Imagem { get; set; }
        [JsonIgnore]
        public virtual TatuadoresModel? TatuadorNav { get; set; }
    }
}
