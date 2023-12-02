<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="compra.aspx.cs" Inherits="tp_web_equipo_19.compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <div class="row">
            <div class="col-7">
                <h3>Elegí la forma de entrega</h3>
                <div class="card border-info mb-3">
                    <div class="card-body">
                        <div class="d-flex flex-column">
                            <div class="form-check">
                                <asp:RadioButton ID="EnvioDomicilio" runat="server" GroupName="formaEntrega" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                                <label for="retiroDomicilio">
                                    Envío a domicilio
                                </label>
                            </div>
                            <div>
                                <asp:Repeater runat="server" ID="Repeater1">
                                    <ItemTemplate>
                                        <div>
                                            <p class="card-text"><b>Ciudad:</b> <%# Eval("Ciudad")%></p>
                                            <p class="card-text"><b>Calle:</b> <%# Eval("Calle")%></p>
                                            <p class="card-text"><b>Altura: </b><%# Eval("Altura") %></p>
                                            <p class="card-text"><b>Piso: </b><%# Eval("Piso") %></p>
                                            <p class="card-text"><b>Dpto: </b><%# Eval("Depto") %></p>

                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <hr />
                        <div>
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
                <div class="botones">
                    <asp:Button runat="server" Style="width: 15%; margin-right: 5px;" type="button" class="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver" />
                    <asp:Button runat="server" Style="width: 15%;" type="button" class="btn btn-primary" OnClick="btnContinuar_Click" Text="Continuar" />
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
                                <th class="text-right">Precio</th>
                            </tr>
                        </thead>

                        <asp:Repeater ID="RepeaterCarrito" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Articulo.Nombre") %></td>
                                    <td class="text-right"><%# string.Format("{0:C}", Eval("Articulo.Precio")) %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td>Envío</td>
                            <td class="text-right">
                                <asp:Label ID="lblEnvio" runat="server" Text="0.00" AutoPostBack="true"></asp:Label></td>
                        </tr>

                    </table>

                    <tr>
                        <td class="text-right" colspan="2"><b>Total:</b><asp:Label ID="lblTotalCarrito" runat="server" Text="0.00" AutoPostBack="true"></asp:Label></td>
                    </tr>


                </div>
            </div>
        </div>
    </div>
    <style>
        .contenedor {
            height: 500px;
            margin: 50px;
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

