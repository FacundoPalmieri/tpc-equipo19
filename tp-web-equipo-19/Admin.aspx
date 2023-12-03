<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="tp_web_equipo_19.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contenedor">
    <h3>KF Market Admin</h3>
    <asp:button runat="server" style="width:10%;" type="button" class="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver"/>

    <hr style="width: 28rem;"/>

        <asp:Button CssClass="card botones" ID="Ventas" runat="server" Text="🛍️ Ventas " OnClick="Ventas_Click" />
        <asp:Button CssClass="card botones" ID="ABM" runat="server" Text="✏️  ABM" OnClick="ABM_Click" />

    </div>



    <style>
        .contenedor {
            height: 500px;
            margin: 50px;
        }

        .botones {
            display:flex;
            justify-content:center;
            align-items: center;
            width: 18rem; 
            height: 100px; 
            margin:15px;
        }
    </style>
</asp:Content>
