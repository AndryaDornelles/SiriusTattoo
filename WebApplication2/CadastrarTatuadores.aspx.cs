using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        //Se mantém na página, verificar depois se existe alguma implementação melhor.                       
                    }
                    else
                    {
                        // O usuário não é um tatuador, esconde o botão.
                        Response.Redirect("Login.aspx");
                    }

                }
            }
            else
            {
                // Nenhum usuário logado, esconda o botão
                Response.Redirect("Login.aspx");
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtNomeTatuador.Text))
            {
                txtNomeTatuador.BorderColor = Color.Red;
                lblResultado.Visible = true;
                lblResultado.Text = "Informe um nome";
                lblResultado.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                txtNomeTatuador.BorderColor = Color.Black;
                lblResultado.Visible = false;
            }
            if (string.IsNullOrEmpty(txtEmailTatuador.Text))
            {
                txtEmailTatuador.BorderColor = Color.Red;
                lblResultado.Visible = true;
                lblResultado.Text = "Informe um email";
                lblResultado.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                txtEmailTatuador.BorderColor = Color.Black;
                lblResultado.Visible = false;
            }
            if (string.IsNullOrEmpty(txtTelefoneTatuador.Text))
            {
                txtTelefoneTatuador.BorderColor = Color.Red;
                lblResultado.Visible = true;
                lblResultado.Text = "Informe um telefone";
                lblResultado.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                txtTelefoneTatuador.BorderColor = Color.Black;
                lblResultado.Visible = false;
            }
            if (string.IsNullOrEmpty(txtEspecialidade.Text))
            {
                txtEspecialidade.BorderColor = Color.Red;
                lblResultado.Visible = true;
                lblResultado.Text = "Informe a especialidade";
                lblResultado.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                txtEspecialidade.BorderColor = Color.Black;
                lblResultado.Visible = false;
            }
            if (string.IsNullOrEmpty(txtSenhaTatuador.Text))
            {
                txtSenhaTatuador.BorderColor = Color.Red;
                lblResultado.Visible = true;
                lblResultado.Text = "Informe um email";
                lblResultado.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                txtSenhaTatuador.BorderColor = Color.Black;
                lblResultado.Visible = false;
            }
            if (string.IsNullOrEmpty(txtRepetirSenhaTatuador.Text))
            {
                txtRepetirSenhaTatuador.BorderColor = Color.Red;
                lblResultado.Visible = true;
                lblResultado.Text = "Informe um email";
                lblResultado.ForeColor = Color.Red;
                isValid = false;
            }
            else
            {
                txtRepetirSenhaTatuador.BorderColor = Color.Black;
                lblResultado.Visible = false;
            }
            return isValid;
        }

        protected void btnCadastrarTatuador_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateInputs();
            string nome = txtNomeTatuador.Text.Trim();
            string email = txtEmailTatuador.Text.Trim();
            string telefone = txtTelefoneTatuador.Text.Trim();
            string especialidade = txtEspecialidade.Text.Trim();
            string senha = txtSenhaTatuador.Text.Trim();
            string repetirSenha = txtRepetirSenhaTatuador.Text.Trim();

            try
            {
                Tatuadores tatuador = new Tatuadores();
                tatuador.Nome = nome;
                tatuador.Email = email;
                tatuador.Telefone = telefone;
                tatuador.Especialidade = especialidade;
                tatuador.Senha = senha; 

                Tatuadores objValidador = new Tatuadores();

                objValidador = objValidador.consultarTatuadoresPorEmail(email);

                if (objValidador != null)
                {
                    lblResultado.Visible = true;
                    lblResultado.Text = "Email já cadastrado.";
                    return;
                }

                tatuador.cadastrarTatuadores(tatuador);

                //Depois de cadastrado notifica com uma mensagem
                lblResultado.Visible = true;
                lblResultado.Text = "Cadastro Efetuado";
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Erro: " + ex.Message;
                lblResultado.Visible = true;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}