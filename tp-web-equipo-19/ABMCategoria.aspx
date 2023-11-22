<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABMCategoria.aspx.cs" Inherits="tp_web_equipo_19.ABMCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="encabezado-tabla">
            <h3 style="width: 90%;">Listado Categorías</h3>
            <asp:Button runat="server" Style="width: 10%; margin-right:5px;" type="button" class="btn btn-primary" OnClick="btnAgregar_Click" Text="Agregar" />
            <asp:Button runat="server" Style="width: 10%;" type="button" class="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver" />
        </div>
        <hr />

        <asp:GridView runat="server" ID="dgvCategorias" DataKeyNames="Id"
            CssClass="table table-hover table-light" AutoGenerateColumns="false"
            OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged"
            OnPageIndexChanging="dgvCategorias_PageIndexChanging"
            AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:CommandField ShowSelectButton="true" SelectText="🔎" HeaderText="Editar" />
            </Columns>
        </asp:GridView>
    </div>

    <style>
        .encabezado-tabla {
            display: flex;
        }

        .container {
            display: block;
            height: 500px;
            justify-content: center;
            padding: 10px;
        }
    </style>
</asp:Content>
