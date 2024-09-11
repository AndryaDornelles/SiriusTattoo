<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebApplication1.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Tela de Caldastro</h3>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" Width="737px" DataKeyNames="Id" DefaultMode="Insert">
        <EditItemTemplate>
            Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Nome:
            <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' />
            <br />
            Email:
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Senha:
            <asp:TextBox ID="SenhaTextBox" runat="server" Text='<%# Bind("Senha") %>' />
            <br />
            Telefone:
            <asp:TextBox ID="TelefoneTextBox" runat="server" Text='<%# Bind("Telefone") %>' />
            <br />
            Endereco:
            <asp:TextBox ID="EnderecoTextBox" runat="server" Text='<%# Bind("Endereco") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Atualizar" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Nome:
            <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# Bind("Nome") %>' />
            <br />
            Email:
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Senha:
            <asp:TextBox ID="SenhaTextBox" runat="server" Text='<%# Bind("Senha") %>' />
            <br />
            Telefone:
            <asp:TextBox ID="TelefoneTextBox" runat="server" Text='<%# Bind("Telefone") %>' />
            <br />
            Endereco:
            <asp:TextBox ID="EnderecoTextBox" runat="server" Text='<%# Bind("Endereco") %>' />
            <br />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Inserir" BackColor="Black" BorderColor="Black" BorderStyle="Inset" Font-Underline="False" ForeColor="Yellow" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" BackColor="Black" BorderColor="Black" BorderStyle="Inset" Font-Underline="False" ForeColor="Yellow" />
        </InsertItemTemplate>
        <ItemTemplate>
            Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Nome:
            <asp:Label ID="NomeLabel" runat="server" Text='<%# Bind("Nome") %>' />
            <br />
            Email:
            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Senha:
            <asp:Label ID="SenhaLabel" runat="server" Text='<%# Bind("Senha") %>' />
            <br />
            Telefone:
            <asp:Label ID="TelefoneLabel" runat="server" Text='<%# Bind("Telefone") %>' />
            <br />
            Endereco:
            <asp:Label ID="EnderecoLabel" runat="server" Text='<%# Bind("Endereco") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Excluir" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Novo" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SiriusTattooConnectionString %>" InsertCommand="INSERT INTO [Clientes] ([Nome], [Email], [Senha], [Telefone], [Endereco]) VALUES (@Nome, @Email, @Senha, @Telefone, @Endereco)" SelectCommand="SELECT * FROM [Clientes]" DeleteCommand="DELETE FROM [Clientes] WHERE [Id] = @Id" UpdateCommand="UPDATE [Clientes] SET [Nome] = @Nome, [Email] = @Email, [Senha] = @Senha, [Telefone] = @Telefone, [Endereco] = @Endereco WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int64" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Nome" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Senha" Type="String" />
            <asp:Parameter Name="Telefone" Type="String" />
            <asp:Parameter Name="Endereco" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Nome" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Senha" Type="String" />
            <asp:Parameter Name="Telefone" Type="String" />
            <asp:Parameter Name="Endereco" Type="String" />
            <asp:Parameter Name="Id" Type="Int64" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
