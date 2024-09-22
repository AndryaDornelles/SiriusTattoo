<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="WebApplication2.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Meus Agendamentos</h2>
        <div class="row" id="divAgendamentos" runat="server">
            <!-- Os cartões de agendamentos serão adicionados aqui -->
        </div>
    </div>

    <style>
        /* Estilos personalizados */
        .card {
            transition: transform 0.2s;
            border-radius: 8px;
        }
        .card:hover {
            transform: scale(1.05);
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
        }
        .badge {
            font-size: 0.85rem;
        }
        .text-primary {
            color: #007bff !important; /* Cor personalizada para destaque */
        }
        /* Fundo suave para a página */
        body {
            background-color: #f8f9fa;
        }
        /* Sombra para o container de agendamentos */
        #divAgendamentos {
            margin-top: 20px;
            padding: 20px;
            border-radius: 10px;
            background-color: #ffffff;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }
    </style>
</asp:Content>