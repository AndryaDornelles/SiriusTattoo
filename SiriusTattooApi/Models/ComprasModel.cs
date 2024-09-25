using System.Text.Json.Serialization;

namespace Api.Models
{
    public class ComprasModel
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long TatuagemId { get; set; }
        public DateTimeOffset DataCompra {  get; set; }

        //Navegações
        [JsonIgnore]
        public virtual ClientesModel? ClienteNav { get; set; }
        [JsonIgnore]
        public virtual TatuagensModel? TatuagemNav { get; set; }
    }
}
