<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarDomicilio.aspx.cs" Inherits="tp_web_equipo_19.EditarDomicilio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 250px; margin: 20px; margin-bottom: 180px;">
        <h4 style="color: #AAC3CD">Agregue el domicilio de entrega </h4>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Pais" class="form-label" style="font-size: 14px;">Pais:</label>
            <asp:DropDownList ID="DDLEditarPais" CssClass="form-control mb-2" runat="server" OnSelectedIndexChanged="DDLEditarPais_SelectedIndexChanged" Style="font-size: 12px; height: 33px;"></asp:DropDownList>
        </div>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Provincia" class="form-label" style="font-size: 14px;">Provincia:</label>
            <asp:DropDownList ID="DDLEditarProvincia" CssClass="form-control mb-2" runat="server" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="DDLEditarProvincia_SelectedIndexChanged" Style="font-size: 12px; height: 33px;">
                <asp:ListItem Text="-- Seleccionar provincia --" Value="" Selected="True"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Ciudad" class="form-label" style="font-size: 14px;">Municipio:</label>
            <asp:DropDownList ID="DDLEditarCiudad" CssClass="form-control mb-2" runat="server" OnSelectedIndexChanged="DDLEditarCiudad_SelectedIndexChanged" Style="font-size: 12px; height: 33px;"></asp:DropDownList>
        </div>
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Calle" class="form-label" style="font-size: 14px;">Calle:</label>
            <asp:TextBox ID="TextBoxEditarCalle" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>

            <label for="Altura" class="form-label" style="font-size: 14px;">Altura:</label>
            <asp:TextBox ID="TextBoxEditarAltura" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>

            <label for="Piso" class="form-label" style="font-size: 14px;">Piso:</label>
            <asp:TextBox ID="TextBoxEditarPiso" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>

            <label for="Depto" class="form-label" style="font-size: 14px;">Depto:</label>
            <asp:TextBox ID="TextBoxEditarDepto" CssClass="form-control mb-2" runat="server" Style="font-size: 12px; height: 25px;"></asp:TextBox>
        </div>

       <div class="form-check" >
           <asp:CheckBox ID="CheckEditarDomicilioEnBase" runat="server" AutoPostBack="True" OnCheckedChanged="CheckEditarDomicilioEnBase_CheckedChanged" />
           <label for="Piso" class="form-label" style="font-size: 14px;">Usar este domicilio para futuros envíos</label>

        </div>

        <div>
            <asp:Label runat="server" ID="MensajeError" Visible="false" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>
        </div>

        <asp:Button ID="ButtonVolver" CssClass="btn btn-secondary" OnClick="ButtonVolver_Click" runat="server" Text="Volver" />
        <asp:Button ID="ButtonSiguiente" CssClass="btn btn-primary" OnClick="ButtonSiguiente_Click" runat="server" Text="Confirmar" />
</asp:Content>

