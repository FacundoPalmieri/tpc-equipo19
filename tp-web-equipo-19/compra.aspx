<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="compra.aspx.cs" Inherits="tp_web_equipo_19.compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <div class="row">
            <div class="col-7">
                <h4>Elegí la forma de entrega</h4>
                <div class="card border-info mb-3">
                    <div class="card-body">
                        <div class="d-flex flex-column">
                            <div class="form-check">
                                <asp:RadioButton ID="EnvioDomicilio" runat="server" GroupName="formaEntrega" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                                <label for="retiroDomicilio">
                                    Envío a domicilio
                                </label>
                            </div>
                            <div class="d-flex justify-content-between" style="margin-left: 23px; margin-top: 10px; font-size: 14px;">
                                <asp:Repeater runat="server" ID="Repeater1">
                                    <ItemTemplate>
                                        <div>
                                            <p class="card-text"><b>Ciudad:</b> <%# Eval("Ciudad")%></p>
                                            <p class="card-text"><b>Calle:</b> <%# Eval("Calle")%></p>
                                            <p class="card-text"><b>Altura: </b><%# Eval("Altura") %> <b>Piso: </b><%# Eval("Piso") %><b> Dpto: </b><%# Eval("Depto") %></b></p>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                        <hr />
                        <div style="margin-left: 20px;">
                            <asp:LinkButton ID="EditarDomicilio" CssClass="link-offset-2 link-bold link-underline" runat="server" OnClick="EditarDomicilio_Click1">Editar Domicilio</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="card border-info mb-3">
                    <div class="card-body">
                        <div class="d-flex flex-column">
                            <div class="form-check">
                                <asp:RadioButton ID="retiroLocal" runat="server" GroupName="formaEntrega" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                                <label for="retiroLocal">
                                    Retirar en un punto de entrega
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
                <h4>Elegí la forma de pago</h4>
                <div class="card border-info mb-3">
                    <div class="card-body">
                    <div class="mb-3">
                        <label for="txtMedioPago" class="form-label">Medio de Pago: </label>
                        <asp:DropDownList runat="server" TextMode="Multiline" ID="ddlMedioPago" CssClass="btn btn-outine-dark drop-down-toggle" OnSelectedIndexChanged="ddlMedioPago_SelectedIndexChanged" />
                    </div>
                    </div>
                </div>
            </div>
            <div class="col-5 card border border-light" style="background: #F9F9F9;">
                <div class="card-body">
                    <h5>Resumen de compra</h5>
                    <hr />

                    <table class="table">
                        <thead>
                            <tr>
                                <th>Producto</th>
                                <th>Cantidad</th>
                                <th class="text-right">Precio Unidad</th>
                            </tr>
                        </thead>

                        <asp:Repeater ID="RepeaterCarrito" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Articulo.Nombre") %></td>
                                    <td><%# Eval("cantidad") %></td>
                                    <td class="text-right"><%# string.Format("{0:C}", Eval("Articulo.Precio")) %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td>Envío</td>
                            <td></td>
                            <td class="text-right">
                                <asp:Label ID="lblEnvio" runat="server" Text="$0.00" AutoPostBack="true"></asp:Label>

                            </td>
                        </tr>

                    </table>

                    <tr>
                        <td class="text-right" colspan="2"><b>Total:</b><asp:Label ID="lblTotalCarrito" runat="server" AutoPostBack="true"></asp:Label></td>
                    </tr>

                    <div>
                        <asp:Label ID="MensajeError" runat="server" Visible="false" CssClass="text-danger"></asp:Label>
                    </div>


                    <div style="margin-top: 5px;">
                        <asp:Button runat="server" CssClass="btn btn-success " OnClick="btnConfirmar_Click" Text="Confirmar compra" />
                        <asp:Button runat="server" CssClass="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver" />
                    </div>

                </div>
            </div>
        </div>
    </div>
    <style>
        .contenedor {
            height: 500px;
            margin: 30px;
        }

        #lblCambioDomicilio:hover {
            color: red;
            cursor: pointer;
            text-decoration: underline;
        }

        .botones {
            display: flex;
            justify-content: end;
        }

        .link-bold {
            font-weight: bold;
        }

        .link-underline {
            text-decoration: underline;
        }
    </style>
</asp:Content>

