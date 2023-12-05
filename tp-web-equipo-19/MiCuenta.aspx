<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="tp_web_equipo_19.MiCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center">
        <h5>Mi cuenta</h5>
            <hr />
            <asp:Button CssClass="card style-card" ID="MisDatos" runat="server" Text="Mis Datos" />
            <asp:Button CssClass="card style-card" ID="CerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="CerrarSesion_Click" />
        </div>
    </div>


    <style>

        .container {
            height: 500px;
            justify-content: center;
            padding: 10px;
            margin: 30px;
        }

        .style-card{
            width: 50%;
            height: 100px;
            align-content: center;
            margin: 10px;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

     
    </style>

</asp:Content>
