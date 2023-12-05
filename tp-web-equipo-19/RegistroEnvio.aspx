<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroEnvio.aspx.cs" Inherits="tp_web_equipo_19.RegistroEnvio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 250px; margin: 20px; margin-bottom: 180px;">
        <h2 style="color: #AAC3CD">¡Solo un paso más!</h2>
        <h4 style="color: #AAC3CD">Confirme sus datos para los próximos envios 😊</h4>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Pais" class="form-label" style="font-size: 14px;">Pais:</label>
            <asp:DropDownList ID="DDLPais" CssClass="form-control mb-2" runat="server" OnSelectedIndexChanged="Pais_SelectedIndexChanged" Style="font-size: 12px; height: 33px;"></asp:DropDownList>
        </div>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Provincia" class="form-label" style="font-size: 14px;">Provincia:</label>
            <asp:DropDownList ID="DDLProvincia" CssClass="form-control mb-2" runat="server" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="DDLProvincia_SelectedIndexChanged" Style="font-size: 12px; height: 33px;">
                <asp:ListItem Text="-- Seleccionar provincia --" Value="" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Ciudad" class="form-label" style="font-size: 14px;">Municipio:</label>
            <asp:DropDownList ID="DDLCiudad" CssClass="form-control mb-2" runat="server" OnSelectedIndexChanged="DDLCiudad_SelectedIndexChanged" Style="font-size: 12px; height: 33px;"></asp:DropDownList>
        </div>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Calle" class="form-label" style="font-size: 14px;">Calle:</label>
            <asp:TextBox ID="TextBoxCalle" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>

            <label for="Altura" class="form-label" style="font-size: 14px;">Altura:</label>
            <asp:TextBox ID="TextBoxAltura" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>

            <label for="Piso" class="form-label" style="font-size: 14px;">Piso:</label>
            <asp:TextBox ID="TextBoxPiso" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>

            <label for="Depto" class="form-label" style="font-size: 14px;">Depto:</label>
            <asp:TextBox ID="TextBoxDepto" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MensajeError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
        </div>

        <asp:Button ID="ButtonVolver" CssClass="btn btn-secondary" OnClick="ButtonVolver_Click" runat="server" Text="Volver" />
        <asp:Button ID="ButtonSiguiente" CssClass="btn btn-primary" OnClick="ButtonSiguiente_Click" runat="server" Text="Siguiente" />
</asp:Content>
