<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña1.aspx.cs" Inherits="tp_web_equipo_19.RecuperarContraseña1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 250px; margin: 20px; margin-bottom: 280px;">
        <h2 style="color: #AAC3CD">Conteste la pregunta de seguridad 🔐</h2>

        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">
            <label for="Usuario" class="form-label">Usuario</label>
        </div>

        <div>
            <asp:TextBox ID="TextBoxUser" CssClass="form-control mb-3" placeholder="nombre@ejemplo.com" runat="server" Style="max-width: 500px;"></asp:TextBox>
        </div>

        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">
            <label for="PreguntaSeguridad" class="form-label">Ingrese su palabra de seguridad</label>
        </div>
        <div>
            <asp:TextBox ID="TextBoxPalabraSeguridad" CssClass="form-control mb-3" runat="server" Style="max-width: 500px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="MensajeError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
        </div>

        <div>
            <asp:Button ID="ButtonVolver3" CssClass="btn btn-secondary" OnClick="ButtonVolver3_Click" runat="server" Text="Volver" />
            <asp:Button ID="ButtonEnviar" CssClass="btn btn-success" OnClick="ButtonEnviar_Click" runat="server" Text="Enviar" />
        </div>
    </div>
</asp:Content>
