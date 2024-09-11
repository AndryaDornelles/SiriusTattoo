<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <formview ID="formLogin" runat="server">
        <div>
            <h1>Login</h1>
            <br />
            <label>Usuário</label><br />
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox><br />
            <label>Senha</label><br />
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" /><br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-se" OnClick="btnCadastrar_Click" /><br />



        </div>
    </formview>
</asp:Content>
