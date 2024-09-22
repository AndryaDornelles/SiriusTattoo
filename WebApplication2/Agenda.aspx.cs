using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebApplication2
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }
        public async Task AtualizarStatusAgendamentosPassados()
        {
            using (var ctx = new SiriusTattooEntities())
            {
                var agendamentos = await ctx.Agenda
                    .Where(a => a.Data_Sessao < DateTime.Now && a.Status != "realizado")
                    .ToListAsync();

                foreach (var agendamento in agendamentos)
                {
                    agendamento.Status = "realizado"; // Atualiza o status
                }

                await ctx.SaveChangesAsync(); // Salva as alterações no banco de dados
            }
        }

        private void LoadAppointments()
        {
            string usuarioEmail = Session["UserEmail"].ToString();

            using (SiriusTattooEntities ctx = new SiriusTattooEntities())
            {
                // Verifica se o usuário é um cliente ou tatuador
                var cliente = ctx.Clientes.FirstOrDefault(c => c.Email == usuarioEmail);
                var tatuador = ctx.Tatuadores.FirstOrDefault(t => t.Email == usuarioEmail);

                if (cliente != null)
                {
                    // Se for um cliente, carrega a agenda associada ao cliente
                    var agendamento = ctx.Agenda
                        .Where(a => a.Cliente_Id == cliente.Id)
                        .Select(a => new
                        {
                            Data_Sessao = a.Data_Sessao,
                            Duracao = a.Duracao,
                            Status = a.Status
                        })
                        .ToList();

                    foreach (var agendamentos in agendamento)
                    {
                        var card = new LiteralControl($@"
                    <div class='col-md-4 mb-4'>
                        <div class='card'>
                            <div class='card-body'>
                                <h5 class='card-title'>Data e Hora: {agendamentos.Data_Sessao:dd/MM/yyyy HH:mm}</h5>
                                <p class='card-text'>Duração: {agendamentos.Duracao}</p>
                                <p class='card-text'>Status: {agendamentos.Status}</p>
                            </div>
                        </div>
                    </div>");
                        divAgendamentos.Controls.Add(card);
                    }
                }
                else if (tatuador != null)
                {
                    // Se for um tatuador, carrega a agenda associada ao tatuador
                    var agendamentos = ctx.Agenda
                        .Where(a => a.Tatuador_Id == tatuador.Id) // Supondo que exista uma coluna Tatuador_Id na tabela Agenda
                        .Select(a => new
                        {
                            Data_Sessao = a.Data_Sessao,
                            Duracao = a.Duracao,
                            Status = a.Status,
                            ClienteNome = ctx.Clientes.FirstOrDefault(c => c.Id == a.Cliente_Id).Nome // Busca o nome do cliente
                        })
                        .ToList();

                    foreach (var agendamento in agendamentos)
                    {
                        var card = new LiteralControl($@"
                    <div class='col-md-4 mb-4'>
                        <div class='card'>
                            <div class='card-body'>
                                <h5 class='card-title'>Data e Hora: {agendamento.Data_Sessao:dd/MM/yyyy HH:mm}</h5>
                                <p class='card-text'>Duração: {agendamento.Duracao}</p>
                                <p class='card-text'>Status: {agendamento.Status}</p>
                                <p class='card-text'>Cliente: {agendamento.ClienteNome}</p> <!-- Exibe o nome do cliente -->
                            </div>
                        </div>
                    </div>");
                        divAgendamentos.Controls.Add(card);
                    }
                }
                else
                {
                    // Tratar caso onde nem cliente nem tatuador são encontrados

                }
            }
        }
    }
}