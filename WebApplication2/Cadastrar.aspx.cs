﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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

        protected async void btnCadastrar_Click(object sender, EventArgs e)
        {
            #region | Validações |
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

            // Validações do formulário
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
                // Envio do novo cliente à API
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7154/api/v1/Clientes/");

                    var novoCliente = new 
                    {
                        Nome = txtNome.Text,
                        Email = txtEmail.Text,
                        Senha = txtSenha.Text,
                        Telefone = txtTelefone.Text,
                        DataNascimento = Convert.ToDateTime(dtNascimento.Text)
                    };

                    var response = await client.PostAsJsonAsync("Cadastro", novoCliente);

                    if (response.IsSuccessStatusCode)
                    {
                        // Cadastro bem-sucedido
                        string script = "alert('Cadastro efetuado com sucesso!'); window.location.href='Login.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        lbResultado.Visible = true;
                        lbResultado.Text = "Erro ao cadastrar: " + response.ReasonPhrase + " - " + errorResponse;
                    }
                }

            }
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}