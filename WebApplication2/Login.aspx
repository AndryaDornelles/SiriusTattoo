﻿<%@ Page Async="true" Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview ID="formLogin" runat="server">
        <div>
            <h1>Login</h1><br />

            <label>Usuário</label><br />
            <asp:TextBox ID="txtUsuario" placeholder="Digite seu email" runat="server" CssClass="form-control"></asp:TextBox><br />
            <asp:Label ID="lbResultaUsuario" runat="server" Visible="false"></asp:Label>

            <label>Senha</label><br />
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
            <asp:Label ID="lbResultadoSenha" runat="server" Visible="false"></asp:Label><br />
            <asp:Label ID="lbResultado" runat="server" Visible="false"></asp:Label>
            <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="btn btn-dark" /><br />
        </div>
        <br />
        <div>
            <h6>Não possui cadastro?</h6> <a href="Cadastrar.aspx">Cadastre-se</a>
        </div>
    </formview>
</asp:Content>