<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroConfirmacion.aspx.cs" Inherits="tp_web_equipo_19.RegistroConfirmación" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 250px; margin: 20px; margin-bottom: 280px;">
        <h2 style="color: #AAC3CD">Confirme su registro 🎉</h2>
        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">

            <label for="Usuario" class="form-label">Usuario</label>
        </div>

        <div>
            <asp:TextBox ID="TextBoxUser" CssClass="form-control mb-3" placeholder="nombre@ejemplo.com" runat="server" Style="max-width: 500px;"></asp:TextBox>
        </div>

        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">

            <label for="lblContraseña" class="form-label">Contraseña</label>
        </div>


        <div>
            <asp:TextBox ID="TextBoxPassword1" type="password" CssClass="form-control mb-3" aria-describedby="passwordHelpBlock" runat="server" Style="max-width: 500px;"></asp:TextBox>
        </div>

        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">
            <label for="lblContraseña2" class="form-label">Reingrese su contraseña</label>
        </div>

        <div>
            <asp:TextBox ID="TextBoxPassword2" type="password" CssClass="form-control mb-3" aria-describedby="passwordHelpBlock" runat="server" Style="max-width: 500px;"></asp:TextBox>
        </div>

        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">
            <label for="PreguntaSeguridad" class="form-label">Palabra de seguridad</label>
        </div>
        <div>
            <asp:TextBox ID="TextBoxPalabraSeguridad" CssClass="form-control mb-3" runat="server" Style="max-width: 500px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="MensajeError" Visible="false" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>
        </div>

        <div>
            <asp:Button ID="ButtonVolver2" CssClass="btn btn-secondary" OnClick="ButtonVolver2_Click" runat="server" Text="Volver" />
            <asp:Button ID="ButtonConfirmar" CssClass="btn btn-success" OnClick="ButtonConfirmar_Click" runat="server" Text="Confirmar" />
        </div>
    </div>
</asp:Content>
