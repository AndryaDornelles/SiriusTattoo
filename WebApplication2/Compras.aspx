<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebApplication2.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" DataKeyNames="Id" Font-Names="false" Font-Underline="False" PageSize="10" Width="559px">
        <Columns>
            <asp:ImageField DataImageUrlField="caminhoImagem" ControlStyle-Height="200px" HeaderText="Tatuagem">
                <ControlStyle Height="200px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Preco" HeaderText="Preço" SortExpression="Preco" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnComprar" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Comprar" OnClick="btnComprar_Click" Text="Comprar Tatuagem" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblDetalhesTatuagem" runat="server" Visible="true"></asp:Label>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString2 %>" 
    SelectCommand="SELECT '~/imagemTatuagem/' + Imagem as caminhoImagem, * FROM [Tatuagens] WHERE Id = @TatuagemId">
    <SelectParameters>
        <asp:QueryStringParameter Name="TatuagemId" QueryStringField="tatuagemId" Type="Int64" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>
