<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisDatos.aspx.cs" Inherits="tp_web_equipo_19.MisDatos" %>

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
        <div id="divMensaje" runat="server" class="alert" visible="false"></div>
        <div class="container" style="margin-top: 10px;">
            <h5>Datos Personales &#x1F9D1; </h5>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <div class="mb-4 row">
                        <label for="txtNombres" class="col-sm-1 col-form-label">Nombres</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtNombres" CssClass="form-control" />
                        </div>

                        <label for="txtApellidos" class="col-sm-1 col-form-label">Apellidos</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtApellidos" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="mb-4 row">
                        <label for="txtDNI" class="col-sm-1 col-form-label">DNI</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
                        </div>

                        <label for="txtCelular" class="col-sm-1 col-form-label">Celular</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtCelular" CssClass="form-control" />
                        </div>
                    </div>


                    <h5>Domicilio registrado &#x1F3E0; </h5>


                    <div class="mb-4 row">
                        <label for="txtProvincia" class="col-sm-1 col-form-label">Provincia</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtProvincia" CssClass="form-control" />
                        </div>

                        <label for="txtCiudad" class="col-sm-1 col-form-label">Municipio</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
                        </div>
                    </div>


                    <div class="mb-4 row">
                        <label for="txtCalle" class="col-sm-1 col-form-label">Calle</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtCalle" OnTextChanged="txtCalle_TextChanged" CssClass="form-control" />
                        </div>

                        <label for="txtAltura" class="col-sm-1 col-form-label">Altura</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtAltura" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="mb-4 row">
                        <label for="txtPiso" class="col-sm-1 col-form-label">Piso</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtPiso" CssClass="form-control" />
                        </div>

                        <label for="txtDpto" class="col-sm-1 col-form-label">Dpto</label>
                        <div class="col-sm-4">
                            <asp:TextBox runat="server" ID="txtDpto" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="alert alert-secondary" role="alert">
                        <p class="mb-0">
                            <strong><em></em></strong> Este domicilio podrá ser actualizado en tu próximo pedido!
                        </p>
                    </div>
                    <div style="margin-right: 5px;" class="mb-4 ">
                        <asp:Button ID="ButtonGuardar" CssClass="btn btn-success" OnClick="ButtonGuardar_Click" runat="server" Text="Guardar" />
                        <asp:Button ID="ButtonVolver" CssClass="btn btn-secondary" OnClick="ButtonVolver_Click" runat="server" Text="Volver" />
                    </div>
                </div>
            </div>
        </div>
    </div>


























</asp:Content>
