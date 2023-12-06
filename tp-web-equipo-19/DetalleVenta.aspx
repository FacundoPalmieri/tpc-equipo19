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
                              <%  if (Session["Usuario"] == null || ((Dominio.Usuario)Session["Usuario"]).TipoUsuario == Dominio.TipoUsuario.Administrador)
                        { %>
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form control btn btn-outine-dark drop-down-toggle" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="false" />
                        <asp:Button runat="server" Style="width: 10%; margin-left: 10px;" ID="btnEditar" CssClass="btn btn-success" OnClick="btnEditar_Click" Text="Editar" />
                        <asp:Button runat="server" Style="width: 10%; margin-left: 10px;" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
                          <% } %>
                        <asp:Button runat="server" Style="width: 10%; margin-left: 10px;" ID="btnVolver" CssClass="btn btn-primary" OnClick="btnVolver_Click" Text="Volver" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <hr />
            <%-- COLUMNA VENTA --%>
            <div class="card w-50  border-info mb-3" style="padding: 3%">
                <div style="justify-content: center;">
                    <h5>Datos compra</h5>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class=" d-flex">
                            <table class="table ">
                                <tr>
                                    <th>
                                        <label for="txtID" class="form-label">ID Venta</label></th>
                                    <td>
                                        <asp:Literal runat="server" ID="litID"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="txtFechaVenta" class="form-label">Fecha</label></th>
                                    <td>
                                        <asp:Literal runat="server" ID="litFechaVenta"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="txtCostoEnvio" class="form-label">Costo envío</label></th>
                                    <td>
                                        <asp:Literal runat="server" ID="litCostoEnvio"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="txtCostoTotal" class="form-label">Costo Total</label></th>
                                    <td>
                                        <asp:Literal runat="server" ID="litCostoTotal"></asp:Literal></td>
                                </tr>
                                <tr>
                                    <th>
                                        <label for="txtMedioPago" class="form-label">Medio de pago</label></th>
                                    <td>
                                        <asp:Literal runat="server" ID="txtMedioPago"></asp:Literal></td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="accordion">
                    <div class="accordion-item">
                        <h2 class="accordion-header" id="headingOne">
                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                <strong>Artículos: </strong>
                            </button>
                        </h2>
                        <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                            <div class="accordion-body">
                                <div class="row">
                                    <div class="col-4">Producto</div>
                                    <div class="col-3">Cantidad</div>
                                    <div class="col-5">Precio Total</div>
                                </div>

                                <div class="row">
                                    <div class="col-4">
                                        <asp:Repeater ID="RepeaterDetalleArticulos" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("Nombre") %></td>
                                                    <hr />
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="col-8">
                                        <asp:Repeater ID="RepeaterDetalleVentas" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <div class="row">
                                                        <div class="col-5">
                                                            <td><%# Eval("Cantidad") %></td>
                                                        </div>
                                                        <div class="col-7">
                                                            <td class="text-right"><%# string.Format("{0:C}", Eval("Precio")) %></td>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- DATOS CLIENTE --%>
            <div class="card w-50 border-info mb-3" style="padding: 3%">
                <div style="justify-content: center;">
                    <h5>Datos cliente</h5>
                </div>
                <div class="d-flex">
                    <table class="table">
                        <tr>
                            <th>
                                <label for="txtIDUsuario" class="form-label">Cliente N°</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litIDUsuario"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtNombreUsuario" class="form-label">Nombre</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litNombreUsuario"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtApellidoUsuario" class="form-label">Apellido</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litApellidoUsuario"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtContactoUsuario" class="form-label">Contacto</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litContactoUsuario"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtMailUsuario" class="form-label">Mail</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litMailUsuario"></asp:Literal></td>
                        </tr>
                    </table>
                </div>
            </div>


            <%-- DATOS ENVÍO --%>
            <div class="card w-50 border-info mb-3" style="padding: 3%">
                <div style="justify-content: center;">
                    <h5>Datos de entrega</h5>
                </div>
                <div class="d-flex">
                    <table class="table">
                        <tr>
                            <th>
                                <label for="txtFormaEnvio" class="form-label">Forma de entrega</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litFormaEnvio"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtProvincia" class="form-label">Provincia</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litProvincia"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtCalle" class="form-label">Calle</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litCalle"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtAltura" class="form-label">Altura</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litAltura"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtPiso" class="form-label">Piso:</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litPiso"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>
                                <label for="txtDepto" class="form-label ms-2">Depto:</label></th>
                            <td>
                                <asp:Literal runat="server" ID="litDepto"></asp:Literal></td>
                        </tr>
                    </table>
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
