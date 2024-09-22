using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CarregarTatuadores();

                // Verifica se o usuário está logado
                if (Session["UserEmail"] != null)
                {

                    string userEmail = Session["UserEmail"].ToString();

                    // Conectar ao banco de dados e verificar o tipo de usuário
                    using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                    {
                        var tatuador = ctx.Tatuadores.FirstOrDefault(t => t.Email == userEmail);

                        if (tatuador != null)
                        {
                            // Tatuador consegue visualizar o botão
                            btnCadastrarTatuagem.Visible = true;
                        }
                        else
                        {
                            // O usuário não é um tatuador, esconde o botão.
                            btnAddTatuagem.Visible = false;
                        }

                    }
                }
                else
                {
                    // Nenhum usuário logado, esconda o botão
                    btnAddTatuagem.Visible = false;
                }
            }
        }

        protected void btnCadastrarTatuagem_Click(object sender, EventArgs e)
        {
            panelCadastroTatuagem.Visible = true;
        }

        protected void btnAddTatuagem_Click(object sender, EventArgs e)
        {
            #region | Validações |

            // Define as cores textBox antes das validações
            lbResultado.Visible = false;
            txtNomeTatuagem.BorderColor = Color.Black;
            txtDescricaoTatuagem.BorderColor = Color.Black;
            txtPreco.BorderColor = Color.Black;
            txtTatuador.BorderColor = Color.Black;
            fupImagemTatuagem.BorderColor = Color.Black;

            string nomeTatuagem = txtNomeTatuagem.Text;
            string descricao = txtDescricaoTatuagem.Text;
            string preco = txtPreco.Text;
            string tatuadorId = txtTatuador.Text;
            string imagem = fupImagemTatuagem.ToString();

            if (string.IsNullOrEmpty(nomeTatuagem))
            {
                lbResultado.Text = "Informe o nome da tatuagem";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtNomeTatuagem.BorderColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(descricao))
            {
                lbResultado.Text = "Informe a descrição";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtDescricaoTatuagem.BorderColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(preco))
            {
                lbResultado.Text = "Informe o valor";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtPreco.BorderColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(tatuadorId))
            {
                lbResultado.Text = "Informe o tatuador";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtTatuador.BorderColor = Color.Red;
            }
            #endregion
            else
            {
                //Pesquisa no banco
                try
                {
                    // Verifica se foi inserida uma imagem
                    if (fupImagemTatuagem.HasFile)
                    {
                        //cria uma string para imagem e mapeia o caminho
                        string caminhoImagem = Server.MapPath("/imagemTatuagem/");
                        string nomeImagem = fupImagemTatuagem.FileName;

                        fupImagemTatuagem.SaveAs(caminhoImagem + nomeImagem);

                        Tatuagens tatuagens = new Tatuagens();
                        tatuagens.Nome = txtNomeTatuagem.Text;
                        tatuagens.Descricao = txtDescricaoTatuagem.Text;
                        tatuagens.Preco = Convert.ToDecimal(txtPreco.Text);
                        tatuagens.Tatuador_Id = Convert.ToInt64(txtTatuador.Text);
                        tatuagens.Imagem = fupImagemTatuagem.FileName;

                        using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                        {
                            ctx.Tatuagens.Add(tatuagens);
                            ctx.SaveChanges();
                            GridView1.DataBind();
                        }
                        panelCadastroTatuagem.Visible = false;
                    }
                    else
                    {
                        lbResultado.Text = "Adicione uma imagem";
                        lbResultado.Visible = true;
                        lbResultado.ForeColor = Color.Red;
                        fupImagemTatuagem.BorderColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lbResultado.Text = ex.Message;
                    lbResultado.Visible = true;
                }
            }

        }

        protected void btnCancelarAddTatuagem_Click(object sender, EventArgs e)
        {
            panelCadastroTatuagem.Visible = false;
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            // Obter o ID da tatuagem a partir do CommandArgument
            long tatuagemId = Convert.ToInt64(((Button)sender).CommandArgument);
            Response.Redirect("Compras.aspx?tatuagemId=" + tatuagemId);
        }

        protected void ddlTatuador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlTatuador.SelectedValue))
            {
                long tatuadorId = Convert.ToInt64(ddlTatuador.SelectedValue);
                using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                {
                    var tatuagens = ctx.Tatuagens
                        .Where(t => t.Tatuador_Id == tatuadorId)
                        .Select(t => new
                        {
                            t.Id,
                            t.Nome,
                            t.Descricao,
                            t.Preco,
                            t.Tatuador_Id,
                            t.Imagem,
                            caminhoImagem = "/imagemTatuagem/" + t.Imagem // Mapeia o caminho da imagem
                        })
                        .ToList();
                    GridView1.DataSource = tatuagens;
                    GridView1.DataBind();
                }
            }
            else
            {
                // Se nenhum tatuador for selecionado, você pode limpar o GridView
                GridView1.DataSource = null; // Limpa a fonte de dados
                GridView1.DataBind(); // Atualiza o GridView
            }

        }
        private void CarregarTatuadores()
        {
            try
            {
                using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                {
                    var tatuadores = ctx.Tatuadores.ToList(); //Carrega todos os tatuadores do banco de dados
                    ddlTatuador.DataSource = tatuadores;
                    ddlTatuador.DataTextField = "Nome"; // Nome a ser exibido
                    ddlTatuador.DataValueField = "Id"; // Id a ser usado como valor
                    ddlTatuador.DataBind();

                    ddlTatuador.Items.Insert(0, new ListItem("Selecione um Tatuador", "")); // Adiciona uma opção inicial

                }
            }
            catch (Exception ex)
            {
                lbResultado.Text = "Erro ao carregar tatuadores: " + ex.Message;
                lbResultado.Visible = true;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex; // Define o novo índice de página
            CarregarTatuagens(); // Método que você deve criar para carregar os dados do GridView novamente
        }
        private void CarregarTatuagens()
        {
            long tatuadorId;
            if (long.TryParse(ddlTatuador.SelectedValue, out tatuadorId))
            {
                using (SiriusTattooEntities ctx = new SiriusTattooEntities())
                {
                    var tatuagens = ctx.Tatuagens
                        .Where(t => t.Tatuador_Id == tatuadorId)
                        .Select(t => new
                        {
                            t.Id,
                            t.Nome,
                            t.Descricao,
                            t.Preco,
                            t.Tatuador_Id,
                            t.Imagem,
                            caminhoImagem = "/imagemTatuagem/" + t.Imagem
                        })
                        .ToList();

                    GridView1.DataSource = tatuagens;
                    GridView1.DataBind();
                }
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
    }
}