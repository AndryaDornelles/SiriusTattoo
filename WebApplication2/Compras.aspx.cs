using WebApplication2;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tatuagemId = btn.CommandArgument;

            // Obtém o ID do cliente da sessão
            string clienteEmail = Session["UserEmail"]?.ToString();

            if (clienteEmail != null && tatuagemId != null)
            {
                using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                {
                    //busca o cliente pelo email para obter o Id
                    var cliente = ctx.Clientes.FirstOrDefault(c => c.Email == clienteEmail);

                    if (cliente != null)
                    {
                        //cria um novo pedido
                        Compras compras = new Compras
                        {
                            Cliente_Id = cliente.Id,
                            Tatuagem_Id = Convert.ToInt64(tatuagemId),
                            DataCompra = DateTime.Now
                        };

                        ctx.Compras.Add(compras);
                        ctx.SaveChanges();

                        // Redireciona para a página de agendamento de sessão
                        Response.Redirect("AgendarSessao.aspx?tatuagemId=" + tatuagemId);
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
            Button btn = (Button)sender;
            long tatuagemId = Convert.ToInt64(btn.CommandArgument);
            string clienteEmail = Session["UserEmail"]?.ToString();

            if (clienteEmail == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            //        var clienteResponse = await HttpClient.GetAsync("$https://localhost:7154/api/Clientes/BuscarPorEmail?email={clienteEmail}");

            //        if (clienteResponse.IsSuccessStatusCode)
            //        {
            //            var cliente = await clienteResponse.Content.ReadFromJsonAsync<Clientes>();
            //            if (cliente != null)
            //            {
            //                var removerResponse = await HttpClient.DeleteAsync($"<https://localhost:7154/api/Compras/Remover?clienteId={cliente.Id}&tatuagemId={tatuagemId}>");
            //                if (removerResponse.IsSuccessStatusCode)
            //                {
            //                    Response.Redirect("Disponiveis.aspx");
            //                }
            //                else
            //                {
            //                    lblDetalhesTatuagem.Text = "Erro ao remover a tatuagem do carrinho.";
            //                }
            //            }
            //            else
            //            {
            //                Response.Redirect("Login.aspx");
            //            }
            //        }
            //        else
            //        {
            //            Response.Redirect("Login.aspx");
            //        }
            //    }
            //}

            using (SiriusTattooEntities ctx = new SiriusTattooEntities())
            {
                // Busca a compra correspondente ao tatuagemId
                var cliente = ctx.Clientes.FirstOrDefault(c => c.Email == clienteEmail);
                if (cliente != null)
                {
                    var compra = ctx.Compras.FirstOrDefault(c => c.Tatuagem_Id == tatuagemId && c.Cliente_Id == cliente.Id);
                    if (compra != null)
                    {
                        ctx.Compras.Remove(compra);
                        ctx.SaveChanges();
                        Response.Redirect("Disponiveis.aspx");
                    }
                    else
                    {
                        lblDetalhesTatuagem.Text = "Tatuagem não encontrada no carrinho.";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}