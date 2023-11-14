<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="tp_web_equipo_19.MiCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg" style="height: 250px; margin: 1px; margin-bottom: 150px;">
        <div class="row justify-content-center align-items-center" style="height: 100%;">
            <asp:Button ID="MisDatos" runat="server" Text="Mis Datos" />
            <asp:Button ID="MisCompras" runat="server" Text="Mis Compras" />
            <asp:Button ID="CerrarSesion" OnClick="CerrarSesion_Click" runat="server" Text="Cerrar Sesión" />
        

        </div>
    </div>
</asp:Content>
