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
            else if (string.IsNullOrEmpty(imagem))
            {
                lbResultado.Text = "Adicione uma imagem";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                fupImagemTatuagem.BorderColor = Color.Red;
            }
            #endregion



        }

        protected void btnCancelarAddTatuagem_Click(object sender, EventArgs e)
        {
            panelCadastroTatuagem.Visible = false;
        }
    }
}