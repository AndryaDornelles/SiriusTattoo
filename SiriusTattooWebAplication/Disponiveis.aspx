<%@ Page Title="Tatuagens" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disponiveis.aspx.cs" Inherits="WebApplication2.WebForm4" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Tatuagens Disponíveis</h2>

        <div class="form-group mb-3">
            <label runat="server" for="ddlTatuador" class="form-label">Escolha um Tatuador</label>
            <asp:DropDownList ID="ddlTatuador" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTatuador_SelectedIndexChanged" CssClass="form-select"></asp:DropDownList>
        </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="Id" CssClass="table table-borderless table-hover" GridLines="None" PageSize="6">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="row align-items-center">
                            <div class="col-md-6">
                                <img src='<%# Eval("caminhoImagem") %>' class="img-fluid rounded" />
                            </div>
                            <div class="col-md-6">
                                <h5 class="mb-2"><%# Eval("Nome") %></h5>
                                <p class="mb-2"><%# Eval("Descricao") %></p>
                                <p class="mb-2"><strong>Preço: <%# Eval("Preco", "{0:C}") %></strong></p>
                                <asp:Button ID="btnComprar" runat="server" CommandArgument='<%# Eval("Id") %>' CommandName="Comprar" OnClick="btnComprar_Click" Text="Comprar Tatuagem" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="pagination-container" />
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString2 %>" 
            SelectCommand="SELECT '~/imagemTatuagem/' + Imagem as caminhoImagem, * FROM [Tatuagens] WHERE Tatuador_Id = @Tatuador_Id">
            <SelectParameters>
                <asp:Parameter Name="Tatuador_Id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <br />
        <asp:Button ID="btnCadastrarTatuagem" runat="server" Text="Cadastrar Nova Tatuagem" Visible="false" OnClick="btnCadastrarTatuagem_Click" CssClass="btn btn-dark mb-3" /><br />
        <asp:Button ID="btnCadastrarTatuador" runat="server" Text="Cadastrar Novo Tatuador" Visible="false" OnClick="btnCadastrarTatuador_Click" CssClass="btn btn-dark mb-3" /><br />

        <asp:Panel ID="panelCadastroTatuagem" runat="server" Visible="false" CssClass="mt-4">
            <h1 class="mb-3">Adicionar Tatuagem</h1>
            <div class="form-group mb-3">
                <label for="txtNomeTatuagem" class="form-label">Nome Tatuagem:</label>
                <asp:TextBox ID="txtNomeTatuagem" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="txtDescricaoTatuagem" class="form-label">Descrição:</label>
                <asp:TextBox ID="txtDescricaoTatuagem" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="txtPreco" class="form-label">Preço:</label>
                <asp:TextBox ID="txtPreco" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="txtTatuador" class="form-label">Tatuador ID:</label>
                <asp:TextBox ID="txtTatuador" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="fupImagemTatuagem" class="form-label">Imagem:</label>
                <asp:FileUpload ID="fupImagemTatuagem" runat="server" CssClass="form-control-file" />
            </div>
            <asp:Label ID="lbResultado" runat="server" Visible="false" CssClass="text-danger mb-3"></asp:Label>

            <div class="d-flex justify-content-end">
                <asp:Button ID="btnCancelarAddTatuagem" runat="server" Text="Cancelar" OnClick="btnCancelarAddTatuagem_Click" CssClass="btn btn-outline-dark me-2" />
                <asp:Button ID="btnAddTatuagem" runat="server" Text="Adicionar" OnClick="btnAddTatuagem_Click" CssClass="btn btn-dark" />
            </div>
        </asp:Panel>
    </div>

    <style>
        .pagination-container {
            margin-top: 20px;
        }
        .pagination-container .pagination {
            justify-content: center;
        }
        .pagination-container .page-link {
            color: #343a40;
        }
        .pagination-container .page-item.active .page-link {
            background-color: #343a40;
            border-color: #343a40;
        }
    </style>
</asp:Content>