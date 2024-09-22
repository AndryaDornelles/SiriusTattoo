using WebApplication2;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http.Json;

namespace WebApplication2
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                // Usuário não está logado, redirecionar para a página de login
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                // Verifica se o ID da tatuagem foi passado na URL
                if (Request.QueryString["tatuagemId"] != null)
                {
                    long tatuagemId = Convert.ToInt64(Request.QueryString["tatuagemId"]);


                    // Aqui você pode buscar os detalhes da tatuagem
                    using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                    {
                        var tatuagem = ctx.Tatuagens.FirstOrDefault(t => t.Id == tatuagemId);
                        if (tatuagem != null)
                        {
                            lblTotal.Text = $"Você selecionou a tatuagem: {tatuagem.Nome} por {tatuagem.Preco:C}";
                        }
                    }
                }
            }
            pnlcarrinho.Visible = true;
        }

        protected async void btnComprar_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                long tatuagemId = Convert.ToInt64(btn.CommandArgument);

                // Obtém o ID do cliente da sessão
                string clienteEmail = Session["UserEmail"]?.ToString();

                if (clienteEmail != null)
                {
                    using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                    {
                        // Busca o cliente pelo email para obter o Id
                        var cliente = ctx.Clientes.FirstOrDefault(c => c.Email == clienteEmail);

                        if (cliente != null)
                        {
                            // Cria um objeto para enviar para a API
                            var comprasRequest = new
                            {
                                ClienteId = cliente.Id,
                                TatuagemId = tatuagemId
                            };

                            // Chama a API
                            using (HttpClient client = new HttpClient())
                            {
                                client.BaseAddress = new Uri("https://localhost:7154/api/");
                                var response = await client.PostAsJsonAsync("Compras/Comprar", comprasRequest);

                                if (response.IsSuccessStatusCode)
                                {
                                    // Redireciona para a página de agendamento de sessão
                                    Response.Redirect("AgendarSessao.aspx?tatuagemId=" + tatuagemId);
                                }
                                else
                                {
                                    // Exibe uma mensagem de erro
                                    lblDetalhesTatuagem.Text = "Erro ao realizar a compra. Tente novamente.";
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Login.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }


    protected void btnRemover_Click(object sender, EventArgs e)
        {
            Response.Redirect("Disponiveis.aspx");
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            PnlPagamento.Visible = true;
            GridView1.Visible = false;
            pnlcarrinho.Visible = false;
            lblTotal.Visible = false;
        }

        protected void Voltar_Click(object sender, EventArgs e)
        {
            PnlPagamento.Visible = false;
            GridView1.Visible = true;
        }
    }
}