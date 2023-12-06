<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="tp_web_equipo_19.MisCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <div class="container">
        <div class="encabezado-tabla">
            <h3 style="width: 90%;">Listado Compras</h3>
            <asp:Button runat="server" Style="width: 10%;" type="button" class="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver" />
        </div>
        <hr />

        <asp:UpdatePanel ID="UpDatePanelFiltro" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>

                <asp:GridView runat="server" ID="dgvVentas" DataKeyNames="Id"
                    CssClass="table table-hover table-light" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged"
                    OnPageIndexChanging="dgvVentas_PageIndexChanging"
                    AllowPaging="true" PageSize="5">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha venta" DataField="FechaCompra" DataFormatString="{0:d}" />
                        <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Detalle" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <style>
        .encabezado-tabla {
            display: flex;
        }

        .container {
            height: 500px;
            justify-content: center;
            padding: 10px;
            margin: 30px;
        }
    </style>



</asp:Content>
