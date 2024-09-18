<%@ Page Title="Agenda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendarSessao.aspx.cs" Inherits="WebApplication2.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <formview id="form1" runat="server">
        <div>
            <asp:Label ID="lblDataSessao" runat="server" Text="Data da Sessão:"></asp:Label>
            <asp:Calendar ID="calendarDataSessao" runat="server" />
            <br />
            <asp:Label ID="lblHoraSessao" runat="server" Text="Hora da Sessão:"></asp:Label>
            <asp:DropDownList ID="ddlHoraSessao" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblDuracao" runat="server" Text="Cada sessão tem duração de 2 horas."></asp:Label>
            <asp:TextBox ID="txtDuracao" runat="server" Text="02:00:00" ReadOnly="true" Visible="false"/>
            <br />
            <asp:Button ID="btnAgendar" runat="server" Text="Agendar" OnClick="btnAgendar_Click" />
        </div>
        <asp:Label ID="lblDetalhes" runat="server"></asp:Label>
    </formview>
    

</asp:Content>
