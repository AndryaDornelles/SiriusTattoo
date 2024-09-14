<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disponiveis.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
        <asp:BoundField DataField="Descricao" HeaderText="Descricao" SortExpression="Descricao" />
        <asp:BoundField DataField="Preco" HeaderText="Preco" SortExpression="Preco" />
    </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString2 %>" ProviderName="<%$ ConnectionStrings:SiriusTattooConnectionString2.ProviderName %>" SelectCommand="SELECT [Nome], [Descricao], [Preco] FROM [Tatuagens]"></asp:SqlDataSource>
    <br />
    <asp:Button ID="btnCadastrarTatuagem" runat="server" Text="Cadastrar Nova Tatuagem" OnClick="btnCadastrarTatuagem_Click" /><br />

    <asp:Panel ID="panelCadastroTatuagem" runat="server" Visible="false">
        <div>
            <h1>Adicionar Tatuagem</h1>
            <br />
            <label>Nome Tatuagem:</label><br />
            <asp:TextBox ID="txtNomeTatuagem" runat="server"></asp:TextBox><br />
            <label>Descrição:</label><br />
            <asp:TextBox ID="txtDescricaoTatuagem" runat="server"></asp:TextBox><br />
            <label>Preço:</label><br />
            <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox><br />
            <label>Tatuador ID:</label><br />
            <asp:TextBox ID="txtTatuador" runat="server"></asp:TextBox><br />
            <label>Imagem:</label>
            <asp:FileUpload ID="fupImagemTatuagem" runat="server" /><br />
            <asp:Label ID="lbResultado" runat="server" Visible="false"></asp:Label><br />

            <asp:Button ID="btnCancelarAddTatuagem" runat="server" Text="Cancelar" OnClick="btnCancelarAddTatuagem_Click" />
            <asp:Button ID="btnAddTatuagem" runat="server" Text="Adicionar" OnClick="btnAddTatuagem_Click" />


        </div>
                
    </asp:Panel>
</asp:Content>
