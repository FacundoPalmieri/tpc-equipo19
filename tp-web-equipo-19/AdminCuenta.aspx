<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminCuenta.aspx.cs" Inherits="tp_web_equipo_19.ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-6">
                <asp:Button CssClass="card style-card" ID="Ventas" runat="server" Text="Ventas" OnClick="Ventas_Click" />
                <asp:Button CssClass="card style-card" ID="ABMArticulos" runat="server" Text="ABM Articulos" OnClick="ABMArticulos_Click" />
            </div>
            <div class="col-6">
                <asp:Button CssClass="card style-card" ID="ABMCategorías" runat="server" Text="ABM Categorías" OnClick="ABMCategorias_Click" />
                <asp:Button CssClass="card style-card" ID="ABMMarcas" runat="server" Text="ABM Marcas" OnClick="ABMMarcas_Click"/>
            </div>
            <div>
                 <asp:Button CssClass="card style-card" ID="CerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="CerrarSesion_Click" />
            </div>
        </div>
    </div>


    <style>
    .container {
        display: flex;
        height: 500px; /* Ajusta según sea necesario */
        justify-content: center;
        padding: 10px;
    }

    .row {
        width: 100%; 
        display: flex;
    }


    .style-card {
        width: 70%;
        height: 20%;
        margin: 5px;
        align-items: center;
        align-content: center;
        justify-content: center;
        display: flex;
    }
</style>
</asp:Content>
