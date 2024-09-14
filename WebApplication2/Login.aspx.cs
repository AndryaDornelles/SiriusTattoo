using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region | Validações |

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.BorderColor = Color.Red;
                lbResultaUsuario.Visible = true;
                lbResultaUsuario.Text = "Informe um Email";
                lbResultaUsuario.ForeColor = Color.Red;
            }
            else
            {
                txtUsuario.BorderColor = Color.Black;
                lbResultaUsuario.Visible = false;
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.BorderColor = Color.Red;
                lbResultadoSenha.Visible = true;
                lbResultadoSenha.Text = "Informe uma senha";
                lbResultadoSenha.ForeColor = Color.Red;
            }
            else
            {
                txtSenha.BorderColor = Color.Black;
                lbResultadoSenha.Visible = false;
            }
            #endregion

            Clientes clientes = new Clientes();
            Tatuadores tatuadores = new Tatuadores();  

            using (SiriusTattooEntities ctx = new SiriusTattooEntities())
            {
                
                clientes = ctx.Clientes.Where(c => c.Email == txtUsuario.Text && c.Senha == txtSenha.Text).FirstOrDefault();
                tatuadores = ctx.Tatuadores.Where(t => t.Email == txtUsuario.Text && t.Senha == txtSenha.Text).FirstOrDefault();

                if ((clientes != null) || (tatuadores != null))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lbResultado.Visible = true;
                    lbResultado.Text = "Usuário ou senha inválidos";
                }
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastrar.aspx");
        }
    }
}