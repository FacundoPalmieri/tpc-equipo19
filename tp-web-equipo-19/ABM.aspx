<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABM.aspx.cs" Inherits="tp_web_equipo_19.ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center">
        <h5> ABM </h5>
            <hr />
            <asp:Button CssClass="card style-card" ID="ABMArticulos" runat="server" Text="ABM Articulos" OnClick="ABMArticulos_Click" />
            <asp:Button CssClass="card style-card" ID="ABMCategorías" runat="server" Text="ABM Categorías" OnClick="ABMCategorias_Click"/>
            <asp:Button CssClass="card style-card" ID="ABMMarcas" runat="server" Text="ABM Marcas" OnClick="ABMMarcas_Click"/>
        </div>
    </div>


    <style>

        .container {
            display: flex;
            height: 500px;
            justify-content: center;
            padding: 10px;
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
