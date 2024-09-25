using Api.Models;
using Api.Repositories.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<TatuadoresModel> Tatuadores { get; set; }
        public DbSet<TatuagensModel> Tatuagens { get; set; }
        public DbSet<ComprasModel> Compras { get; set; }
        public DbSet<AgendaModel> Agenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AgendaMap());
            modelBuilder.ApplyConfiguration(new ClientesMap());
            modelBuilder.ApplyConfiguration(new ComprasMap());
            modelBuilder.ApplyConfiguration(new TatuadoresMap());
            modelBuilder.ApplyConfiguration(new TatuagensMap());
        }
    }
}