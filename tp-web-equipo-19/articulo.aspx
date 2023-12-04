<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="articulo.aspx.cs" Inherits="tp_web_equipo_19.articulo" %>

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
        <h5>Carga de datos</h5>

        <hr />
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtID" class="form-label">ID Artículo</label>
                    <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCodigoArticulo" class="form-label">Codigo Artículo</label>
                    <asp:TextBox runat="server" ID="txtCodigoArticulo" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox runat="server" TextMode="Multiline" ID="txtDescripcion" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtMarca" class="form-label">Marca</label>
                    <asp:DropDownList runat="server" TextMode="Multiline" ID="ddlMarca" CssClass="btn btn-outine-dark drop-down-toggle" />
                </div>
                <div class="mb-3">
                    <label for="txtCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList runat="server" TextMode="Multiline" ID="ddlCategoria" CssClass="btn btn-outine-dark drop-down-toggle" />
                </div>
            </div>
            <div class="col-6">
                <asp:UpdatePanel ID="UpDatePaneImagen" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagen" class="form-label">➕ URL Imágen</label>
                            <asp:TextBox runat="server" ID="TextBoxURL" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                            <asp:Image runat="server" ID="imgArticulo" Width="80%" CssClass="img-fluid mb-3" Style="display: flex; align-content: center; padding: 10px; margin-left: 60px;" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div>
            <div class="row botones">
                <asp:Button runat="server" Style="width: 20%; margin-right: 10px;" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
                <asp:Button runat="server" Style="width: 20%;" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Text="Cancelar" />
            </div>
            <asp:UpdatePanel ID="UpDatePanelEliminar" runat="server">
                <ContentTemplate>

                    <div class="row">
                        <asp:Button runat="server" Style="width: 19.5%; margin-bottom: 10px;" OnClick="btnEliminar_Click" CssClass="btn btn-danger" Text="Eliminar" />
                    </div>

                    <%if (ConfirmaEliminacion)
                        {%>
                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <asp:CheckBox runat="server" Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" />
                                <asp:Button Text="Eliminar" ID="btnConfirmarEliminacion" OnClick="btnConfirmarEliminacion_Click" CssClass="btn btn-outline-danger" runat="server" />
                            </div>
                        </div>
                    </div>
                    <%}%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript">

        function imgError(image) {
            image.onerror = "";
            image.src = 'https://static.vecteezy.com/system/resources/previews/005/337/799/non_2x/icon-image-not-found-free-vector.jpg';
            image.style.Width = "80%";
            return true;
        }

    </script>

    <style>
        .container {
            margin: 30px;
        }

        .card {
            margin-bottom: 20px;
        }

        .botones {
            display: flex;
            width: 47%;
            justify-content: start;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
