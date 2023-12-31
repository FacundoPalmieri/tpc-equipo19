﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="tp_web_equipo_19.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />

    <div style="padding: 20px; align-items: center; display: flex; justify-content: center; flex-direction: column;">
        <div class="d-flex align-items-center" style="width: 40%;">
            <asp:TextBox ID="txtBuscador" runat="server" CssClass="form-control txtBuscador" />
            <asp:Button Text="Buscar" CssClass="btn btn-secondary boton-buscar" runat="server" OnClick="btnBuscar_Click" />
        </div>
        <div class="d-flex align-items-start mt-3">
            <asp:CheckBox ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" Font-Bold="true" ForeColor="#808080" Text="Filtro avanzado" />
        </div>
    </div>

    <% if (FiltroAvanzado)
        { %>
    <asp:UpdatePanel ID="UpDatePanelFiltro" runat="server">
        <ContentTemplate>
            <div class="row" style="padding: 20px; align-items: center; display: flex; justify-content: center;">
                <div class="col-3" style="margin-left: 10px">
                    <div class="mb-3">
                        <asp:Label ID="lblCampo" runat="server" Text="Campo" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Todo" Value="" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3" style="margin-left: 10px">
                    <div class="mb-3">
                        <asp:Label ID="lblCriterio" runat="server" Text="Criterio" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3" style="margin-left: 10px">
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Filtro" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row" style="padding: 20px; align-items: center; display: flex; justify-content: center;">
        <div class="col-2">
            <div class="mb-3">
                <asp:Button Text="Buscar" CssClass="btn btn-primary" runat="server" OnClick="btnFiltro_Click" />
            </div>
        </div>
    </div>
    <% } %>


    <div class="row row-cols-1 row-cols-md-3 g-4" style="margin: 20px;">
        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card custom-card">
                        <!-- Agrega la clase personalizada custom-card -->
                        <img src='<%# Eval("Imagen.ImagenUrl")%>' onerror="imgError(this);" class="card-img-top" alt="Imagen" style="width: 300px; height: 355px;">

                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <%--     <p class="card-text"><%# Eval("Descripcion")%></p>--%>
                            <p class="card-text"><b>Marca: </b><%# Eval("Marca.Descripcion") %></p>
                            <p class="card-text"><b>Categoría: </b><%# Eval("Categoria.Descripcion") %></p>
                            <p class="card-text"><b>Precio: </b><%# string.Format("{0:C}", Eval("Precio")) %></p>
                            <button type="button" class="btn btn-secondary" onclick="verDetalle(<%#Eval("Id") %>);">Ver Detalle</button>

                            <script>
                                function verDetalle(id) {
                                    window.location.href = 'DetalleArticulo.aspx?id=' + id;
                                }
                            </script>
                            <%  if (Session["Usuario"] == null || !(Session["Usuario"] is Dominio.Usuario) || ((Dominio.Usuario)Session["Usuario"]).TipoUsuario == Dominio.TipoUsuario.Cliente)
                                { %>
                            <asp:Button Text="Añadir al Carrito" CssClass="btn btn-primary" runat="server" ID="btnAniadirAlCarrito" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnAniadirAlCarrito_Click" />
                            <% } %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script type="text/javascript">
        function imgError(image) {
            image.onerror = "";
            image.src = 'https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg';
            return true;
        }
    </script>

    <style>
        .boton-buscar {
            margin-left: 10px;
            max-inline-size: 80px;
        }

        .txtBuscador {
            max-inline-size: 800px;
        }

        .filtros {
            max-inline-size: 80%;
            padding: 30px;
        }

        .vertical-center {
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 10px;
        }

        /* Estilo para las tarjetas */
        .custom-card {
            max-height: 550px; /* Altura máxima de la tarjeta */
            overflow: hidden; /* Oculta cualquier desbordamiento */
            width: 310px;
            display: flex;
            align-items: center; /* Centra verticalmente la imagen */
            justify-content: center; /* Centra horizontalmente la imagen */
        }

       /* Estilo para las imágenes dentro de las tarjetas */
       .custom-card img {
           object-fit: cover; /* La imagen se ajustará al contenedor */
           max-width: 100%; /* La imagen no excederá el ancho de la tarjeta */
           max-height: 100%; /* La imagen no excederá el 100% de la altura de la tarjeta */
           width: 350px;
           margin-top: 3px;
           margin-right: 3px;
           margin-left: 3px;
       }
    </style>



</asp:Content>
