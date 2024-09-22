using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se o usuário está logado
            if (Session["UserEmail"] != null)
            {
                // Se usuário logado, exiba o botão para logout
                btnLogout.Visible = true;
                btnLogin.Visible = false;
            }
            else
            {
                // Nenhum usuário logado, esconda o botão
                btnLogout.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            // Limpar sessão
            Session.Clear();
            // Redirecionar para a página de login
            Response.Redirect("Login.aspx");
           
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}