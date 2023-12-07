<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="tp_web_equipo_19.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style>
        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .card {
            max-width: 400px;
            padding: 20px;
            text-align: center;
        }

        .carousel-inner {
            margin-top: 20px;
        }

        .carousel-item img {
            width: 200px;
            height: 200px;
            object-fit: cover;
        }
    </style>

    <div class="container">
        <div class="card">
            <h3 style="color: #AAC3CD;" class="card-title">Detalle de artículo 🔍</h3>
            <div class="carousel-inner">
                <asp:Repeater runat="server" ID="Repeater1">
                    <ItemTemplate>
                        <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <p class="card-text"><b>Descripción:</b> <%# Eval("Descripcion")%></p>
                            <p class="card-text"><b>Marca: </b><%# Eval("Marca.Descripcion") %></p>
                            <p class="card-text"><b>Categoría: </b><%# Eval("Categoria.Descripcion") %></p>
                            <p class="card-text"><b>Precio: </b><%# string.Format("{0:C}", Eval("Precio")) %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div id="Carousel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater runat="server" ID="Carousel">
                        <ItemTemplate>
                            <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                <img src='<%# Container.DataItem as string %>' onerror="imgError(this);" style="max-width:300px; max-height:300px;" class="img-fluid" alt="Imagen">
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" href="#Carousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </a>
                <a class="carousel-control-next" href="#Carousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </a>
            </div>

            <div class="text-center mt-3"> 
                <asp:Button ID="ButtonVolver" CssClass="btn btn-secondary" OnClick="ButtonVolver_Click" runat="server" Text="Volver" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function imgError(image) {
            image.onerror = "";
            image.src = 'https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg';
            image.style.width = "300px";
            image.style.height = "300px";
            return true;
        }
    </script>
</asp:Content>
