<%@ Page Title="Carrinho de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="WebApplication2.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Carrinho de Compras</h2>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" DataKeyNames="Id" CssClass="table table-hover">
            <Columns>
                <asp:ImageField DataImageUrlField="caminhoImagem" ControlStyle-Height="200px" HeaderText="Tatuagem">
                    <ControlStyle Height="200px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Preco" HeaderText="Preço" SortExpression="Preco" DataFormatString="{0:C}" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnRemover" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnRemover_Click" Text="Remover" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnComprar" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Comprar" OnClick="btnComprar_Click" Text="Comprar Tatuagem" CssClass="btn btn-success" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NextPrevious" />
        </asp:GridView>

        <div class="text-end mt-3">
            <asp:Label ID="lblTotal" runat="server" CssClass="font-weight-bold"></asp:Label>
        </div>

        <asp:Label ID="lblDetalhesTatuagem" runat="server"></asp:Label>

        <asp:SqlDataSource ID="SqlDataSource1"
            runat="server"
            ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString2 %>"
            SelectCommand="SELECT '~/imagemTatuagem/' + Imagem as caminhoImagem, * FROM [Tatuagens] WHERE Id = @TatuagemId">
            <SelectParameters>
                <asp:QueryStringParameter Name="TatuagemId" QueryStringField="tatuagemId" Type="Int64"/>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

    <style>
        h2 {
            color: #343a40; /* Cor do título */
        }
        .card {
            border: none; /* Remove bordas padrão */
            margin-bottom: 20px; /* Espaçamento entre os cartões */
        }
    </style>
</asp:Content>