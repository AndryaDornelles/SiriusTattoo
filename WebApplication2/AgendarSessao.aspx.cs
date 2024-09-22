using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        if (!IsPostBack)
            {
                for (int hour = 9; hour <= 19; hour += 2)
                {
                    ddlHoraSessao.Items.Add(new ListItem($"{hour:D2}:00", hour.ToString()));
                }

                if (Request.QueryString["tatuagemId"] != null)
                {
                    long tatuagemId = Convert.ToInt64(Request.QueryString["tatuagemId"]);

                    using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                    {
                        var tatuagem = ctx.Tatuagens.FirstOrDefault(t => t.Id == tatuagemId);
                        if (tatuagem != null)
                        {
                            // Opcional: Exibir detalhes da tatuagem se necessário
                            lblDetalhes.Text = $"Você selecionou a tatuagem: {tatuagem.Nome}";
                        }
                    }
                }
            }
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            string clienteEmail = Session["UserEmail"]?.ToString();
            long tatuagemId = Convert.ToInt64(Request.QueryString["tatuagemId"]);
            DateTime dataHoraSessao;
            TimeSpan duracao; //duração fixa de 2 horas

            // Combinar a data do calendário com a hora do DropDownList
            string dataSessaoStr = calendarDataSessao.SelectedDate.ToString("yyyy-MM-dd") + " " + ddlHoraSessao.SelectedItem.Text;

            if (!calendarDataSessao.SelectedDate.Date.Equals(DateTime.Today) && calendarDataSessao.SelectedDate.Date < DateTime.Today)
            {
                lblDetalhes.Text = "Você não pode agendar uma sessão em uma data passada.";
                return;
            }

            if (DateTime.TryParse(dataSessaoStr, out dataHoraSessao) && TimeSpan.TryParse(txtDuracao.Text, out duracao))
            {
                using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                {
                    var cliente = ctx.Clientes.FirstOrDefault(c => c.Email == clienteEmail);
                    var tatuagem = ctx.Tatuagens.FirstOrDefault(t => t.Id == tatuagemId);

                    if (cliente != null && tatuagem != null)
                    {
                        // Verifica se já existe um agendamento para a mesma data e hora
                        var agendamentoExistente = ctx.Agenda.Any(a =>
                            a.Data_Sessao == dataHoraSessao &&
                            a.Tatuador_Id == tatuagem.Tatuador_Id);

                        if (agendamentoExistente)
                        {
                            lblDetalhes.Text = "Esse horário já está agendado. Por favor, escolha outro horário.";
                            return;
                        }
                        Agenda novaAgenda = new Agenda
                        {
                            Cliente_Id = cliente.Id,
                            Tatuador_Id = tatuagem.Tatuador_Id,
                            Data_Sessao = dataHoraSessao,
                            Duracao = duracao,
                            Status = "Agendado" // ou outro status inicial desejado
                        };

                        ctx.Agenda.Add(novaAgenda);
                        ctx.SaveChanges();

                        // Confirmar agendamento ou redirecionar para outra página
                        Response.Redirect("Agenda.aspx");

                    }
                    else
                    {
                        lblDetalhes.Text = "Cliente ou tatuagem não encontrados.";
                    }
                }
            }
            else
            {
                lblDetalhes.Text = "Por favor, selecione uma data e hora válidas.";
            }
        }
    }

}