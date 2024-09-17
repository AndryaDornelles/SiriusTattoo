<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarTatuadores.aspx.cs" Inherits="WebApplication2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <formview ID="formCadastrarTatuagem" runat="server">
    <div>
        <h1>Cadastrar Tatuador</h1><br />
        <label>Nome Completo:</label><br />
        <asp:TextBox ID="txtNomeTatuador" runat="server"></asp:TextBox><br />
        <label>Email:</label><br />
        <asp:TextBox ID="txtEmailTatuador" runat="server"></asp:TextBox><br />
        <label>Telefone:</label><br />
        <asp:TextBox ID="txtTelefoneTatuador" runat="server"></asp:TextBox><br />
        <label>Especialidade:</label><br />
        <asp:TextBox ID="txtEspecialidade" runat="server"></asp:TextBox><br />
        <label>Senha:</label><br />
        <asp:TextBox ID="txtSenhaTatuador" runat="server" TextMode="Password"></asp:TextBox><br />
        <label>Repetir Senha:</label><br />
        <asp:TextBox ID="txtRepetirSenhaTatuador" runat="server" TextMode="Password"></asp:TextBox> <br />
        <asp:Label ID="lblResultado" runat="server" Visible="false"></asp:Label><br /><br />

        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnCadastrarTatuador" runat="server" Text="Cadastrar" OnClick="btnCadastrarTatuador_Click" />

    </div>
        </formview>
</asp:Content>
