<%@ Page Title="Cadastrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview ID="formCadastrar" runat="server">
         <div>
             <h1>Cadastre-se</h1>
             <br/>
             <label>Nome Completo:</label>
             <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox><br />
             <label>Email:</label>
             <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
             <label>Telefone:</label>
             <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox><br />
             <label>Data de Nascimento:</label>
             <asp:TextBox ID="dtNascimento" runat="server" TextMode="Date" CssClass="form-control date-picker"></asp:TextBox><br />
             <label>Senha</label>
             <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
             <label>Repetir Senha</label>
             <asp:TextBox ID="txtRepetirSenha" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
             <asp:Label ID="lbResultado" runat="server" Visible="false"></asp:Label><br />
             <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" OnClientClick="return confirmeSair()" CssClass="btn btn-outline-dark" />
             <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" CssClass="btn btn-dark" />


         </div>
    </formview>
</asp:Content>
