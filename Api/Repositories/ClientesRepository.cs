using Api.Models;
using Api.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ClientesRepository
    {
        private readonly DataContext context;

        public ClientesRepository(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration.GetConnectionString("connection"));

            options.UseSqlServer();
            context = new DataContext(options.Options);
        }

        // Método para autenticar cliente
        public ClientesModel AutenticarUser(string email, string senha)
        {
            string hashedSenha = HashPassword(senha);

            var cliente = context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);
            return cliente;
        }
        private string HashPassword(string password)
        {
            // SHA-256 é uma função de hash criptográfico que gera um valor de 256 bits (32 bytes) a partir da entrada.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        //Método para buscar cliente por Id
        public ClientesModel? BuscarPorID (long Id)
        {
            return context.Clientes.Where(x => x.Id == Id).FirstOrDefault();
        }

        //Método para buscar todos os clientes
        public IEnumerable<ClientesModel> BuscarTodos()
        {
            return context.Clientes;
        }
        public async Task<long> CadastrarCliente(ClientesModel cliente)
        {
            try
            {
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();
                return cliente.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar tatuador.", ex);
            }
        }
    }
}
