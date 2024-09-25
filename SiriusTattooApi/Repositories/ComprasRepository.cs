using Api.Models;
using Api.Repositories.Contexts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class ComprasRepository
    {
        private readonly DataContext _context;

        public ComprasRepository(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration.GetConnectionString("connection"));

            options.UseSqlServer();
            _context = new DataContext(options.Options);
        }

        public IEnumerable<ComprasModel> BuscarTodas()
        {
            return _context.Compras;
        }
        public IEnumerable<ComprasModel> BuscarPorTatuador(long tatuadorId)
        {
            return _context.Compras.Where(c => c.TatuagemNav.TatuadorId == tatuadorId);
        }
        public IEnumerable<ComprasModel> BuscarPorCliente(long clienteId)
        {
            return _context.Compras.Where(c => c.ClienteId == clienteId);
        }
        public async Task<long> CadastrarCompra(ComprasRequest comprasRequest)
        {
            if (comprasRequest == null)
                throw new ArgumentNullException(nameof(comprasRequest));

            try
            {
                var compra = new ComprasModel
                {
                    ClienteId = comprasRequest.ClienteId,
                    TatuagemId = comprasRequest.TatuagemId,
                    DataCompra = DateTimeOffset.Now,
                };

                await _context.Compras.AddAsync(compra);
                await _context.SaveChangesAsync();
                return compra.Id; // Retorna o ID da nova compra
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar compra.", ex);
            }
        }
    }
}
