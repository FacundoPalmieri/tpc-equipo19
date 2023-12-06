<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCuenta.aspx.cs" Inherits="tp_web_equipo_19.ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row row-botones style-card">

            <asp:Button ID="Ventas" CssClass="boton card" runat="server" Text="Ventas" OnClick="Ventas_Click" />
            <asp:Button ID="ABMArticulos" CssClass="boton card" runat="server" Text="ABM Articulos" OnClick="ABMArticulos_Click" />


            <asp:Button ID="ABMCategorías" CssClass="boton card" runat="server" Text="ABM Categorías" OnClick="ABMCategorias_Click" />
            <asp:Button ID="ABMMarcas" CssClass="boton card" runat="server" Text="ABM Marcas" OnClick="ABMMarcas_Click" />

        </div>
        <div class="row row-botones style-card">
            <asp:Button ID="CerrarSesion" CssClass="boton card" runat="server" Text="Cerrar Sesión" OnClick="CerrarSesion_Click" />
        </div>

    </div>

    <style>
        .container {
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
            flex-wrap: wrap;
            height: 400px;
          
        }

        .row-botones
        {
            width: 70%;
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
        }


        .style-card {
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            align-content: center;
            justify-content: center;
        }

        .boton {
            width: 35%;
            margin: 20px;
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
            height: 70px;
        }

        .col-6 {
            flex: 0 0 auto;
            width: 50%;
        }
    </style>
</asp:Content>
