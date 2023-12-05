<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="tp_web_equipo_19.DetalleVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <div class="container">

        <div class="container">
            <h5>Detalle de venta</h5>
            <hr />
            <div class="row">
                <div class="col-md-6">

                    <div class="mb-3">
                        <label for="txtID" class="form-label">ID Venta</label>
                        <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtFechaVenta" class="form-label">Fecha</label>
                        <asp:TextBox runat="server" ID="txtFechaVenta" CssClass="form-control" DataFormatString="{0:d}" />
                    </div>
                    <div class="mb-3">
                        <label for="txtCostoEnvio" class="form-label">Costo envío</label>
                        <asp:TextBox runat="server" ID="txtCostoEnvio" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtCostoTotal" class="form-label">Costo Total</label>
                        <asp:TextBox runat="server" ID="txtCostoTotal" CssClass="form-control" />
                    </div>
                    <h5>Artículos: </h5>
                    <hr />
                    <asp:Repeater ID="RepeaterDetalleArticulos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>Id: <%# Eval("IdArticulo") %></td><br>
                                <td>Nombre: <%# Eval("IdArticulo") %></td>
                                <td>Cantidad: <%# Eval("Cantidad") %></td>
                                <td class="text-right">Precio: <%# string.Format("{0:C}", Eval("Precio")) %></td>
                                <hr />
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-md-6">

                    <div class="mb-3">
                        <label for="txtIDUsuario" class="form-label">Cliente N°</label>
                        <asp:TextBox runat="server" ID="txtIDUsuario" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtNombreUsuario" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtApellidoUsuario" class="form-label">Apellido</label>
                        <asp:TextBox runat="server" ID="txtApellidoUsuario" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtContactoUsuario" class="form-label">Contacto</label>
                        <asp:TextBox runat="server" ID="txtContactoUsuario" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtMailUsuario" class="form-label">Mail</label>
                        <asp:TextBox runat="server" ID="txtMailUsuario" CssClass="form-control" />
                    </div>



                    <div class="row botones">
                        <asp:Button runat="server" Style="width: 40%; margin-right: 10px;" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
                        <asp:Button runat="server" Style="width: 40%;" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Text="Cancelar" />
                    </div>
                </div>
            </div>
        </div>


        <style>
            .container {
                /*height: 500px;*/
                justify-content: center;
                padding: 10px;
                margin: 30px;
            }

            .card {
                margin-bottom: 20px;
            }

            .botones {
                display: flex;
                width: 47%;
                justify-content: end;
                margin-bottom: 10px;
            }
        </style>
</asp:Content>
