<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABM.aspx.cs" Inherits="tp_web_equipo_19.ABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-lg" style="height: 250px; margin: 1px; margin-bottom: 150px;">
        <div class="row justify-content-center align-items-center" style="height: 100%;">
            <asp:Button ID="ABMArticulos" runat="server" Text="ABM Articulos" />
            <asp:Button ID="ABMCatergorias" runat="server" Text="ABM Catergorias" />
            <asp:Button ID="ABMMarcas" runat="server" Text="ABMMarcas" />

        </div>
    </div>
</asp:Content>
