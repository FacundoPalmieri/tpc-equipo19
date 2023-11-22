<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABMMarca.aspx.cs" Inherits="tp_web_equipo_19.ABMMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="encabezado-tabla">
            <h3 style="width:90%;">Listado Marcas</h3>
            <asp:button runat="server" style="width:10%; margin-right:5px;" type="button" class="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar"/>
            <asp:button runat="server" style="width:10%;" type="button" class="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver"/>
        </div>
        <hr />

        <asp:GridView runat="server" ID="dgvMarcas" DataKeyNames="Id" 
            CssClass="table table-hover table-light" AutoGenerateColumns="false"
            OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged"
            onPageIndexChanging = "dgvMarcas_PageIndexChanging"
            AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="🔎" HeaderText="Editar" />
            </Columns>
        </asp:GridView>
    </div>

    <style>
        .encabezado-tabla{
            display:flex;
        }
        .container {
            display: block;
            height: 500px;
            justify-content: center;
            padding: 10px;
        }
    </style>
</asp:Content>
