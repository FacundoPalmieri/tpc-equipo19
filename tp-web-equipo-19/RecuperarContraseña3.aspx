<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña3.aspx.cs" Inherits="tp_web_equipo_19.RecuperarContraseña3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
                <h2 style="color: #AAC3CD;">Se ha restablecido tu contraseña &#x2705;</h2>

                <div class="mb-4" style="margin: 150px;">
                    <asp:Button ID="ButtonContinuar" CssClass="btn btn-success" OnClick="ButtonContinuar_Click" runat="server" Text="Continuar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

