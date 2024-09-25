<%@ Page Title="Agenda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgendarSessao.aspx.cs" Inherits="WebApplication2.WebForm7" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container mt-5">
<h2>Agendar Sessão de Tatuagem</h2>
<p>Por favor, selecione a data e a hora de sua preferência.</p>

    <div class="form-group">
        <asp:Label ID="lblDataSessao" runat="server" Text="Data da Sessão:" CssClass="form-label"></asp:Label>
        <asp:Calendar ID="calendarDataSessao" runat="server" CssClass="form-control" OnClientClick="setMinDate();" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblHoraSessao" runat="server" Text="Hora da Sessão:" CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="ddlHoraSessao" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label ID="lblDuracao" runat="server" Text="Cada sessão tem duração de 2 horas." CssClass="form-text"></asp:Label>
        <asp:TextBox ID="txtDuracao" runat="server" Text="02:00:00" ReadOnly="true" Visible="false" CssClass="form-control"/>
    </div>
    <asp:Button ID="btnAgendar" runat="server" Text="Agendar" OnClick="btnAgendar_Click" CssClass="btn btn-primary" />

    <asp:Label ID="lblDetalhes" runat="server" CssClass="text-danger mt-3"></asp:Label>

</div>
<script type="text/javascript">
    function setMinDate() {
        var today = new Date();
        var day = ("0" + today.getDate()).slice(-2);
        var month = ("0" + (today.getMonth() + 1)).slice(-2); // Meses começam em 0
        var year = today.getFullYear();
        var minDate = year + "-" + month + "-" + day;

        var calendar = document.getElementById('<%= calendarDataSessao.ClientID %>');
        calendar.setAttribute("min", minDate);
    }
</script>

</asp:Content>