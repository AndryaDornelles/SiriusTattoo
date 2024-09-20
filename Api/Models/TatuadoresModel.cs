using System.Text.Json.Serialization;

namespace Api.Models
{
    public class TatuadoresModel
    {
        public long Id { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Especialidade { get; set; }

        [JsonIgnore]
        public ICollection<TatuagensModel>? Tatuagens { get; set; }
    }
}
