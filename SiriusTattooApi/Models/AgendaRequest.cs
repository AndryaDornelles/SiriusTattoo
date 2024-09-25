using System.Text.Json.Serialization;

namespace Api.Models
{
    public class AgendaRequest
    {
        [JsonIgnore]
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long TatuadorId { get; set; }
        public DateTimeOffset? DataSessao { get; set; }
        public string? Status { get; set; }
    }
}
