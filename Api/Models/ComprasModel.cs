namespace Api.Models
{
    public class ComprasModel
    {
        public long Id { get; set; }
        public ClientesModel Cliente { get; set; }
        public TatuagensModel Tatuagem { get; set; }
        public DateTimeOffset DataCompra {  get; set; }
    }
}
