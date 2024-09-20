namespace Api.Models
{
    public class ComprasModel
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public long TatuagemId { get; set; }
        public DateTimeOffset DataCompra {  get; set; }

        //Navegações
        public virtual ClientesModel ClienteNav { get; set; }
        public virtual TatuagensModel TatuagemNav { get; set; }
    }
}
