using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                // Usuário não está logado, redirecionar para a página de login
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCadastrarTatuagem_Click(object sender, EventArgs e)
        {
            panelCadastroTatuagem.Visible = true;
        }

        protected void btnAddTatuagem_Click(object sender, EventArgs e)
        {
            #region | Validações |

            // Define as cores textBos antes das validações
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
    }
}