<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroConfirmacion.aspx.cs" Inherits="tp_web_equipo_19.RegistroConfirmación" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 250px; margin: 20px; margin-bottom: 180px;">
        <h2 style="color: #AAC3CD">Confirme su registro!</h2>
        <h4 style="color: #AAC3CD">Ingrese su usuario y contraseña </h4>
        <div>
            <asp:TextBox ID="TextBoxUser" CssClass="form-control mb-3" placeholder="nombre@ejemplo.com" runat="server"></asp:TextBox>
        </div>


        <div class="font weight-bold blockquote" style="color: #AAC3CD; display: flex">

            <label for="inputPassword5" class="form-label">Contraseña</label>
        </div>

        <div>
            <asp:TextBox ID="TextBoxPassword" type="password" CssClass="form-control mb-3" aria-describedby="passwordHelpBlock" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label runat="server" ID="MensajeError" Visible="false" Text="" CssClass="text-danger"></asp:Label>
        </div>

        <div>
            <asp:Button ID="ButtonVolver2" CssClass="btn btn-secondary" OnClick="ButtonVolver2_Click" runat="server" Text="Volver" />
            <asp:Button ID="ButtonConfirmar" CssClass="btn btn-success" OnClick="ButtonConfirmar_Click" runat="server" Text="Confirmar" />
        </div>
    </div>
</asp:Content>
