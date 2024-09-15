<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disponiveis.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" DataKeyNames="Id" Font-Names="false" Font-Underline="False" PageSize="1" Width="559px">
    <Columns>
        <asp:ImageField DataImageUrlField="caminhoImagem" ControlStyle-Height="500px" HeaderText="Tatuagem">
<ControlStyle Height="500px"></ControlStyle>
        </asp:ImageField>
        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" />
        <asp:BoundField DataField="Nome" Visible="false" HeaderText="Nome" SortExpression="Nome" />
        <asp:BoundField DataField="Descricao" Visible="false" HeaderText="Descricao" SortExpression="Descricao" />
        <asp:BoundField DataField="Preco" HeaderText="Preco" SortExpression="Preco" />
        <asp:BoundField DataField="Tatuador_Id" visible="false" HeaderText="Tatuador_Id" SortExpression="Tatuador_Id" />
        <asp:BoundField DataField="Imagem" Visible="false" HeaderText="Imagem" SortExpression="Imagem" />
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnComprar" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Agendar" OnClick="btnComprar_Click" Text="Agendar Sessão" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString2 %>" SelectCommand="SELECT '~/imagemTatuagem/' + Imagem as caminhoImagem, * FROM [Tatuagens]"></asp:SqlDataSource>
    <br />
    <asp:Button ID="btnCadastrarTatuagem" runat="server" Text="Cadastrar Nova Tatuagem" Visible="false" OnClick="btnCadastrarTatuagem_Click" Width="237px" /><br />

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
            <label>Imagem:</label><br />
            <asp:FileUpload ID="fupImagemTatuagem" runat="server" Width="294px" /><br />
            <asp:Label ID="lbResultado" runat="server" Visible="false"></asp:Label><br />

            <asp:Button ID="btnCancelarAddTatuagem" runat="server" Text="Cancelar" OnClick="btnCancelarAddTatuagem_Click" />
            <asp:Button ID="btnAddTatuagem" runat="server" Text="Adicionar" OnClick="btnAddTatuagem_Click" />


        </div>
                
    </asp:Panel>
</asp:Content>
