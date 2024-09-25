using Api.Models;
using Api.Repositories.Contexts;
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
                string duracaoString = "02:00:00"; // String representando a duração.
                TimeSpan duracao;

                // Tentando converter a string para TimeSpan
                if (TimeSpan.TryParse(duracaoString, out duracao))
                {
                    // A conversão foi bem-sucedida, você pode usar a variável 'duracao' aqui.
                }
                else
                {
                    // Lidar com o erro caso a conversão falhe
                    throw new FormatException("A duração fornecida não está em um formato válido.");
                }

                var agenda = new AgendaModel
                {
                    ClienteId = agendaRequest.ClienteId,
                    TatuadorId = agendaRequest.TatuadorId,
                    DataSessao = agendaRequest.DataSessao,
                    Duracao = duracao,
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
