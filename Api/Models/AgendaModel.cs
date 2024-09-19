namespace Api.Models
{
    public class AgendaModel
    {
        public long Id { get; set; }
        public ClientesModel Cliente { get; set; }
        public TatuadoresModel Tatuador { get; set; }
        public DateTimeOffset DataSessao { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Status { get; set; }
    }
}
