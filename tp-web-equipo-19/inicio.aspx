<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="tp_web_equipo_19.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="vertical-center"><h3>LISTADO DE ARTICULOS </h3></div>
    
    <div style="padding: 20px; align-items:center; display: flex; justify-content: center;">
        <div class="d-flex align-items-center">
            <asp:TextBox ID="txtBuscador" runat="server" CssClass="form-control txtBuscador" />
            <asp:Button Text="Buscar" CssClass="btn btn-primary boton-buscar" runat="server" OnClick="btnBuscar_Click" />
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4" style="margin: 20px;">
        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src='<%# Eval("Imagen.ImagenUrl")%>' onerror="imgError(this);" class="card-img-top" alt="Imagen">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <p class="card-text"><%# Eval("Descripcion")%></p>
                            <p class="card-text"><b>Marca: </b><%# Eval("Marca.Descripcion") %></p>
                            <p class="card-text"><b>Categoría: </b><%# Eval("Categoria.Descripcion") %></p>
                            <p class="card-text"><b>Precio: </b><%# string.Format("{0:C}", Eval("Precio")) %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                            <asp:Button Text="Añadir al Carrito" CssClass="btn btn-primary" runat="server" ID="btnAniadirAlCarrito" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnAniadirAlCarrito_Click" />
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
    </style>

</asp:Content>
