<%@ Page Title="Cadastrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview ID="formCadastrar" runat="server">
         <div>
             <h1>Cadastre-se</h1>
             <br/>
             <label>Nome Completo:</label><br />
             <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
             <label>Email:</label><br />
             <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
             <label>Telefone:</label><br />
             <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox><br />
             <label>Data de Nascimento:</label><br />
             <asp:TextBox ID="dtNascimento" runat="server" TextMode="Date"></asp:TextBox><br />
             <label>Senha</label><br />
             <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
             <label>Repetir Senha</label><br />
             <asp:TextBox ID="txtRepetirSenha" runat="server" TextMode="Password"></asp:TextBox><br />
             <asp:Label ID="lbResultado" runat="server" Visible="false"></asp:Label><br />

             <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" OnClientClick="return confirmeSair()" />
             <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />


         </div>
    </formview>
</asp:Content>
