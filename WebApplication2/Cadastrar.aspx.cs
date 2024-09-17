using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            #region | Validações |

            // Define cores textBox antes das validações
            lbResultado.Visible = false;
            txtNome.BorderColor = Color.Black;
            txtEmail.BorderColor = Color.Black;
            txtTelefone.BorderColor = Color.Black;
            txtSenha.BorderColor = Color.Black;
            txtRepetirSenha.BorderColor = Color.Black;
            dtNascimento.BorderColor = Color.Black;

            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            string senha = txtSenha.Text;
            string repetirSenha = txtRepetirSenha.Text;
            
            // Validando se é maior de idade.
            decimal idade = 0;

            // Controle de erro caso data = null 
            try
            {
                DateTime dataNascimento = Convert.ToDateTime(dtNascimento.Text);
                DateTime dataAtual = DateTime.Now;
                idade = dataAtual.Subtract(dataNascimento).Days / 365;
            }
            catch 
            { 
                idade = 0;
            }
            if (string.IsNullOrEmpty(dtNascimento.Text))
            {
                lbResultado.Text = "Informe sua data de nascimento";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                dtNascimento.BorderColor = Color.Red;
            }
            else if (idade < 18)
            {
                lbResultado.Text = "Não permitido para menores de 18 anos";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(nome))
            {
                lbResultado.Text = "Preencha seu nome";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtNome.BorderColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(email))
            {
                lbResultado.Text = "Preencha seu email";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtEmail.BorderColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(telefone))
            {
                lbResultado.Text = "Preencha seu telefone";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtTelefone.BorderColor = Color.Red;
            }
            else if (senha != repetirSenha)
            {
                lbResultado.Text = "Senhas diferentes";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtSenha.BorderColor = Color.Red;
                txtRepetirSenha.BorderColor = Color.Red;
            }
            else if (string.IsNullOrEmpty(senha))
            {
                lbResultado.Text = "Preencha sua senha";
                lbResultado.Visible = true;
                lbResultado.ForeColor = Color.Red;
                txtSenha.BorderColor = Color.Red;
                txtRepetirSenha.BorderColor = Color.Red;
            }
            #endregion
            else
            {
                //Pesquisa no banco
                // verifica se email já existe no banco de dados
                // se estiver disponivel o email ele cadastra
                try
                {
                    Clientes clientes = new Clientes();
                    clientes.Nome = txtNome.Text;
                    clientes.Email = txtEmail.Text;
                    clientes.Telefone = txtTelefone.Text;
                    clientes.Data_Nascimento = Convert.ToDateTime(dtNascimento.Text);
                    clientes.Senha = txtSenha.Text;

                    Clientes objValidador = new Clientes();
                    
                    objValidador = objValidador.consultarClientesPorEmail(txtEmail.Text);

                    if (objValidador != null)
                    {
                        lbResultado.Visible = true;
                        lbResultado.Text = "Email já cadastrado.";
                    }
                    else
                    {
                        clientes.cadastrarClientes(clientes);
                     // Depois de cadastrado retorna para o login
                        Response.Redirect("Login.aspx");
                    }
                }
                catch (Exception ex)
                {
                    lbResultado.Text = "Erro: " + ex.Message;
                    lbResultado.Visible = true;
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}