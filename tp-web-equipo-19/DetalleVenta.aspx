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
        <div>
            <h5>Detalle de venta</h5>
            <hr />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3 d-flex">
                        <label for="ddlEstado" class="form-label">Estado</label>
                        <asp:TextBox runat="server" ID="txtEstado" CssClass="form-control" Style="width: 20%; margin-left: 10px;" ReadOnly="true" />
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form control btn btn-outine-dark drop-down-toggle" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="false" />
                        <asp:Button runat="server" Style="width: 10%; margin-left: 10px;" ID="btnEditar" CssClass="btn btn-success" OnClick="btnEditar_Click" Text="Editar" />
                        <asp:Button runat="server" Style="width: 10%; margin-left: 10px;" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row">
                <hr />
                <%-- COLUMNA VENTA --%>
                <div class="col-md-4">
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
                    <div class="accordion acordion">
                        <div class="accordion-item">
                            <h2 class="accordion-header" id="headingOne">
                                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                    <strong>Artículos: </strong>
                                </button>
                            </h2>
                            <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                                <div class="accordion-body">
                                    <asp:Repeater ID="RepeaterDetalleArticulos" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>Id: <%# Eval("IdArticulo") %></td>
                                                <td>Cantidad: <%# Eval("Cantidad") %></td>
                                                <td class="text-right">Precio: <%# string.Format("{0:C}", Eval("Precio")) %></td>
                                                <hr />
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- COLUMNA CLIENTE --%>
                <div class="col-md-4">
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
                </div>
                <%-- COLUMNA ENVÍO --%>
                <div class="col-md-4">
                    <div class="mb-3">
                        <label for="txtFormaEnvio" class="form-label">Forma de entrega</label>
                        <asp:TextBox runat="server" ID="txtFormaEnvio" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtProvincia" class="form-label">Provincia</label>
                        <asp:TextBox runat="server" ID="txtProvincia" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtCalle" class="form-label">Calle</label>
                        <asp:TextBox runat="server" ID="txtCalle" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtAltura" class="form-label">Altura</label>
                        <asp:TextBox runat="server" ID="txtAltura" CssClass="form-control" />
                    </div>
                    <div class="mb-3 d-flex" style="margin-top: 13%">
                        <label for="txtPiso" class="form-label">Piso:</label>
                        <asp:TextBox runat="server" ID="txtPiso" CssClass="form-control" />
                        <label for="txtDepto" class="form-label ms-2">Depto:</label>
                        <asp:TextBox runat="server" ID="txtDepto" CssClass="form-control" />
                    </div>


                </div>
            </div>
        </div>
    </div>

    <style>
        .container {
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

        .acordion {
            margin-top: 9%;
        }
    </style>
</asp:Content>
