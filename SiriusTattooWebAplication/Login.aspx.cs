using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
            // Validações
            bool isValid = ValidateInputs();

            if (!isValid)
            {
                return;
            }
            // Autenticação
            bool isAuthenticated = AuthenticateUser(txtUsuario.Text, txtSenha.Text);

            if (isAuthenticated)
            {
                // Armazena a sessão
                Session["UserEmail"] = txtUsuario.Text;
                // Redireciona se der tudo certo
                Response.Redirect("Home.aspx");
            }
            else
            {
                lbResultado.Visible = true;
                lbResultado.Text = "Usuário ou senha inválidos";
            }
        }
        #region | Validações |
        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                txtUsuario.BorderColor = Color.Red;
                lbResultaUsuario.Visible = true;
                lbResultaUsuario.Text = "Informe um Email";
                lbResultaUsuario.ForeColor = Color.Red;
                isValid = false;
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
                isValid = false;
            }
            else
            {
                txtSenha.BorderColor = Color.Black;
                lbResultadoSenha.Visible = false;
            }
            return isValid;

        }
        #endregion

        private bool AuthenticateUser(string email, string senha)
        {
            Clientes clientes = new Clientes();
            Tatuadores tatuadores = new Tatuadores();

            using (SiriusTattooEntities ctx = new SiriusTattooEntities())
            {
                // Hash da senha fornecida
                var hashedSenha = HashPassword(senha);

                // Buscar o usuário com a senha hash
                clientes = ctx.Clientes.Where(c => c.Email == txtUsuario.Text && c.Senha == hashedSenha).FirstOrDefault();
                tatuadores = ctx.Tatuadores.Where(t => t.Email == txtUsuario.Text && t.Senha == hashedSenha).FirstOrDefault();

                if ((clientes != null) || (tatuadores != null))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lbResultado.Visible = true;
                    lbResultado.Text = "Usuário ou senha inválidos";
                }

                return clientes != null || tatuadores == null;
            }
        }
        private string HashPassword(string password)
        {
            // SHA-256 é uma função de hash criptográfico que gera um valor de 256 bits (32 bytes) a partir da entrada.
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}