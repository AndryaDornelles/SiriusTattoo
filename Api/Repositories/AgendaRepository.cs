using Api.Models;
using Api.Repositories.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class AgendaRepository
    {
        private readonly DataContext _context;

        public AgendaRepository(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<DataContext>();
            options.UseSqlServer(configuration.GetConnectionString("connection"));

            options.UseSqlServer();
            _context = new DataContext(options.Options);
        }

        public IEnumerable <AgendaModel> BuscarToda()
        {
            return _context.Agenda;
        }
        public IEnumerable<AgendaModel> BuscarPorCliente(long clienteId)
        {
            return _context.Agenda.Where(c => c.ClienteId == clienteId);
        }
        public IEnumerable<AgendaModel> BuscarPorTatuador(long tatuadorId)
        {
            return _context.Agenda.Where(t => t.TatuadorId == tatuadorId);
        }
        public async Task<long> CadastrarAgenda(AgendaRequest agendaRequest)
        {
            if (agendaRequest == null) 
                throw new ArgumentNullException(nameof(agendaRequest));

            try
            {
                var agenda = new AgendaModel
                {
                    ClienteId = agendaRequest.ClienteId,
                    TatuadorId = agendaRequest.TatuadorId,
                    Status = agendaRequest.Status
                };
                await _context.Agenda.AddAsync(agenda);
                await _context.SaveChangesAsync();
                return agendaRequest.Id;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao agendar.", ex);
            }
        }

        
    }
}
