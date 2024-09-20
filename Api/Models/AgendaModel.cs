namespace Api.Models
{
    public class AgendaModel
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long TatuadorId { get; set; }
        public DateTimeOffset DataSessao { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Status { get; set; }

        public virtual ClientesModel ClienteNav { get; set; }
        public virtual TatuadoresModel TatuadorNav { get; set; }
    }
}
