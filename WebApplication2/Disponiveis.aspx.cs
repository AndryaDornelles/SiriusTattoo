using System;
using System.Collections.Generic;
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

            #endregion

        }

        protected void btnCancelarAddTatuagem_Click(object sender, EventArgs e)
        {
            panelCadastroTatuagem.Visible = false;
        }
    }
}