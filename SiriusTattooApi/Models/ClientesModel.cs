using System;

namespace Api.Models
{
    public class ClientesModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }

        public ClientesModel() { }

        public ClientesModel(ClientesRequest request, ClientesModel clientes)
        {

            Nome = request.Nome;
            Email = request.Email;
            Telefone = request.Telefone;
            DataNascimento = request.DataNascimento;
        }
    }


}
