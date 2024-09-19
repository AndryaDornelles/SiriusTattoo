<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarTatuadores.aspx.cs" Inherits="WebApplication2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview ID="formCadastrarTatuagem" runat="server">
    <div>
        <h1>Cadastrar Tatuador</h1><br />
        <label>Nome Completo:</label>
        <asp:TextBox ID="txtNomeTatuador" runat="server" CssClass="form-control"></asp:TextBox><br />
        <label>Email:</label>
        <asp:TextBox ID="txtEmailTatuador" runat="server" CssClass="form-control"></asp:TextBox><br />
        <label>Telefone:</label>
        <asp:TextBox ID="txtTelefoneTatuador" runat="server" CssClass="form-control"></asp:TextBox><br />
        <label>Especialidade:</label>
        <asp:TextBox ID="txtEspecialidade" runat="server" CssClass="form-control"></asp:TextBox><br />
        <label>Senha:</label>
        <asp:TextBox ID="txtSenhaTatuador" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox><br />
        <label>Repetir Senha:</label>
        <asp:TextBox ID="txtRepetirSenhaTatuador" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox> <br />
        <asp:Label ID="lblResultado" runat="server" Visible="false"></asp:Label><br />

        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-dark" />
        <asp:Button ID="btnCadastrarTatuador" runat="server" Text="Cadastrar" OnClick="btnCadastrarTatuador_Click" CssClass="btn btn-dark" />

    </div>
        </formview>
</asp:Content>
