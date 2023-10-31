<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tp_web_equipo_19.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tamanio">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <div class="vertical-center">
                <h3>LISTADO DE COMPRAS </h3>
            </div>
            <table class="table">
                <thead>
                    <tr>
                        <th class="auto-style1">PRODUCTO</th>
                        <th class="auto-style1">DESCRIPCION</th>
                        <th class="auto-style1">PRECIO</th>
                        <th class="auto-style1">CANTIDAD</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RepeaterCarrito" runat="server">
                        <itemtemplate>
                            <tr>
                                <td><%# Eval("Articulo.Nombre") %></td>
                                <td><%# Eval("Articulo.Descripcion") %></td>
                                <td><%# string.Format("{0:C}", Eval("Articulo.Precio")) %></td>
                                <td>
                                    <asp:TextBox type="number" min="1" ID="txtCantidad" AutoPostBack="true" runat="server" CssClass="col-lg-4" Text='<%# Eval("cantidad") %>' OnTextChanged="txtCantidad_TextChanged" />
                                    <asp:Button ID="EliminarProducto" AutoPostBack="true" runat="server" Text="Eliminar Producto" OnClick="EliminarProducto_Click" CommandArgument='<%# Eval("Articulo.Id") %>' />

                                </td>
                            </tr>
                        </itemtemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div>
            <td><b>Total:</b><asp:Label ID="lblTotalCarrito" runat="server" Text="0.00"></asp:Label></td>
        </div>
    </div>
    <style>
        .vertical-center {
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 10px;
        }


        .auto-style1 {
            height: 21px;
        }

        .container {
            height: 700px;
        }
    </style>
</asp:Content>
