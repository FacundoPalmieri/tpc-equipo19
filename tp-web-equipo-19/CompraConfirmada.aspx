<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CompraConfirmada.aspx.cs" Inherits="tp_web_equipo_19.CompraConfirmada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-8 text-center">
                <h2 style="color: #AAC3CD;">¡Compra realizada! &#x2705;</h2>
                <div>
                    <asp:Label runat="server" ID="LabelComprobante" Text="Tu número de comprobante es:"> </asp:Label>
                    <strong><%--Muestra el contenido en negrita--%>
                        <asp:Label runat="server" ID="lblComprobante" Text=""></asp:Label>
                    </strong>
                </div>
                <p>Nos estaremos comunicando contigo para coordinar el pago y la entrega por estos medios:</p>
                <div>
                    <asp:Label runat="server" ID="LabelMail" Text="📧 - Correo Electrónico:"> </asp:Label>
                    <asp:Label runat="server" ID="lblMail" Text="- "></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" ID="LabelCelular" Text="📱 - Celular:"> </asp:Label>
                    <asp:Label runat="server" ID="lblCelular" Text="- "></asp:Label>
                </div>

                <div class="mb-4" style="margin: 50px;">
                    <asp:Button ID="ButtonContinuar" CssClass="btn btn-success" OnClick="ButtonContinuar_Click" runat="server" Text="Continuar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
