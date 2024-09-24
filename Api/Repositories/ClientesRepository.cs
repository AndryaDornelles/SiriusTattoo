using Api.Models;
using Api.Repositories.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ClientesRepository
    {
        private readonly DataContext _context;

        public ClientesRepository(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration.GetConnectionString("connection"));

            options.UseSqlServer();
            _context = new DataContext(options.Options);
        }

        // Método para autenticar cliente
        public ClientesModel AutenticarUser(string email, string senha)
        {
            string hashedSenha = HashPassword(senha); // Gere o hash da senha fornecida

            var cliente = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == hashedSenha);
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
        public ClientesModel? BuscarPorId (long Id)
        {
            return _context.Clientes.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<ClientesModel> BuscarTodos()
        {
            return _context.Clientes;
        }
        public async Task<long> CadastrarCliente(ClientesModel cliente)
        {
            try
            {
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return cliente.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar tatuador.", ex);
            }
        }
        public async Task<long> DeletarClientePorId(long id)
        {
            try
            {
                // Busca o cliente pelo ID
                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    throw new Exception("Cliente não encontrado.");
                }

                // Remove o cliente do contexto
                _context.Clientes.Remove(cliente);

                // Salva as alterações no banco de dados
                await _context.SaveChangesAsync();

                // Retorna o ID do cliente removido
                return cliente.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover cliente.", ex);
            }
        }
    }
}
