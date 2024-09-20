using Api.Models;
using Api.Repositories.Contexts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class TatuagensRepository
    {
        private readonly DataContext _context;

        public TatuagensRepository(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration.GetConnectionString("connection"));

            options.UseSqlServer();
            _context = new DataContext(options.Options);
        }
        public IEnumerable<TatuagensModel> BuscarTodas()
        {
            return _context.Tatuagens;
        }
        public async Task<long> CadastrarTatuagem(TatuagensModel tatuagem)
        {
            try
            {
                await _context.Tatuagens.AddRangeAsync(tatuagem);
                await _context.SaveChangesAsync();
                return tatuagem.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar tatuagem.", ex);
            }


        }
    }
}
