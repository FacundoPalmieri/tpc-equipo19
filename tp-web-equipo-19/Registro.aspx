<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="tp_web_equipo_19.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="height: 250px; margin: 20px; margin-bottom: 180px;">
<h2 style ="color:#AAC3CD">Registrese! 📝</h2>
<h4 style ="color:#AAC3CD">Datos personales </h4>
    <div style="height: 100%;">
        <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Nombres" class="form-label" style="font-size: 14px;">Nombres:</label>
            <asp:TextBox ID="TextBoxNombre" CssClass="form-control mb-2" runat="server" style="font-size: 12px; height: 25px;"></asp:TextBox>
        </div>
      <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Apellidos" class="form-label" style="font-size: 14px;">Apellidos:</label>
            <asp:TextBox ID="TextBoxApellido" CssClass="form-control mb-2" runat="server" style="font-size: 12px; height: 25px;"></asp:TextBox>
        </div>
         <div class="col-6" style="display: flex; margin-top: 10px;">
    <label for="Tipo" class="form-label" style="font-size: 14px;">Tipo DNI:</label>
    <asp:DropDownList ID="DDLTipoDni" CssClass="form-control mb-2" runat="server" style="font-size: 12px; height: 25px; width: 80px;"></asp:DropDownList>
    <label for="DNI" class="form-label" style="font-size: 14px;">Número:</label>
    <asp:TextBox ID="TextBoxDNI" CssClass="form-control mb-2" runat="server" style="font-size: 12px; height: 25px;"></asp:TextBox>
</div>

          <div class="col-6" style="display: flex; margin-top: 10px;">
            <label for="Contacto" class="form-label" style="font-size: 14px;">Celular:</label>
            <asp:TextBox ID="TextBoxContacto" CssClass="form-control mb-2" runat="server" style="font-size: 12px; height: 25px;"></asp:TextBox>
        </div>
         <asp:Button ID="ButtonSiguiente" class="btn btn-primary" OnClick="ButtonSiguiente_Click" runat ="server" Text="Siguiente" />
      

            
    </div>
</div>

</asp:Content>
