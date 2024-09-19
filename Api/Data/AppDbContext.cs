using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<TatuadoresModel> Tatuadores { get; set; }
        public DbSet<TatuagensModel> Tatuagens { get; set; }
        public DbSet<ComprasModel> Compras { get; set; }
        public DbSet<AgendaModel> Agenda { get; set; }
    }
}
