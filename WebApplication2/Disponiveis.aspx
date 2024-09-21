<%@ Page Title="Tatuagens" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disponiveis.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Tatuagens Disponíveis</h2>

        <div class="form-group">
            <label runat="server" ForeColor="ddlTatuador">Escolha um Tatuador</label>
            <asp:DropDownList ID="ddlTatuador" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTatuador_SelectedIndexChanged"></asp:DropDownList>
        </div><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="Id" Font-Names="false" Font-Underline="False" PageSize="1" Width="559px" CssClass="table table-bordered table-hover">
            <Columns>
                <asp:ImageField DataImageUrlField="caminhoImagem" ControlStyle-Height="500px" HeaderText="Tatuagem">
                    <ControlStyle Height="500px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Nome" Visible="false" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Descricao" Visible="false" HeaderText="Descricao" SortExpression="Descricao" />
                <asp:BoundField DataField="Preco" HeaderText="Preco" SortExpression="Preco" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Tatuador_Id" visible="false" HeaderText="Tatuador_Id" SortExpression="Tatuador_Id" />
                <asp:BoundField DataField="Imagem" Visible="false" HeaderText="Imagem" SortExpression="Imagem" />
        
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnComprar" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Comprar" OnClick="btnComprar_Click" Text="Comprar Tatuagem" CssClass="btn btn-success" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="table-header" HorizontalAlign="Center" Wrap="True" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString2 %>" 
            SelectCommand="SELECT '~/imagemTatuagem/' + Imagem as caminhoImagem, * FROM [Tatuagens] WHERE Tatuador_Id = @Tatuador_Id">
            <SelectParameters>
                <asp:Parameter Name="Tatuador_Id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="btnCadastrarTatuagem" runat="server" Text="Cadastrar Nova Tatuagem" Visible="false" OnClick="btnCadastrarTatuagem_Click" Width="237px" CssClass="btn btn-dark" /><br />

        <asp:Panel ID="panelCadastroTatuagem" runat="server" Visible="false" CssClass="mt-4"><br />
            <div class="form-group">
                <h1>Adicionar Tatuagem</h1>
            </div>
            <label>Nome Tatuagem:</label>
            <asp:TextBox ID="txtNomeTatuagem" runat="server" CssClass="form-control"></asp:TextBox><br />
            
            <label>Descrição:</label>
            <asp:TextBox ID="txtDescricaoTatuagem" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Preço:</label>
            <asp:TextBox ID="txtPreco" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Tatuador ID:</label>
            <asp:TextBox ID="txtTatuador" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Imagem:</label>
            <asp:FileUpload ID="fupImagemTatuagem" runat="server" Width="294px" /><br />
            <asp:Label ID="lbResultado" runat="server" Visible="false" CssClass="text-danger"></asp:Label><br />

            <asp:Button ID="btnCancelarAddTatuagem" runat="server" Text="Cancelar" OnClick="btnCancelarAddTatuagem_Click" CssClass="btn btn-outline-dark" />
            <asp:Button ID="btnAddTatuagem" runat="server" Text="Adicionar" OnClick="btnAddTatuagem_Click" CssClass="btn btn-dark" />
        </asp:Panel>
    </div>
</asp:Content>