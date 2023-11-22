<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="categoria.aspx.cs" Inherits="tp_web_equipo_19.categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <h5>Carga de datos</h5>

    <hr />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtID" class="form-label">ID Artículo</label>
                <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" TextMode="Multiline" ID="txtDescripcion" CssClass="form-control" />
            </div>
        </div>

        <div class="container">
            <div class="row botones">
                <asp:Button runat="server" Style="width: 20%; margin-right: 10px;" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" />
                <asp:Button runat="server" Style="width: 20%;" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Text="Cancelar" />
            </div>
            <asp:UpdatePanel ID="UpDatePanelEliminar" runat="server">
                <ContentTemplate>

                    <div class="row">
                        <asp:Button runat="server" Style="width: 19.5%; margin-bottom: 10px;" OnClick="btnEliminar_Click" CssClass="btn btn-danger" Text="Eliminar" />
                    </div>
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
    <style>
        .container {
            margin-top: 20px;
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
