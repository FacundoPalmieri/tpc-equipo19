<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="tp_web_equipo_19.Pedidos" %>

<%@ Register TagPrefix="asp" Namespace="System.Web.UI.WebControls" Assembly="System.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css">


    <div class="container">
        <div class="encabezado-tabla">
            <h3 style="width: 90%;">Listado Ventas 💰</h3>
            <asp:Button runat="server" Style="width: 10%;" type="button" class="btn btn-secondary" OnClick="btnVolver_Click" Text="Volver" />
        </div>
        <hr />

        <asp:UpdatePanel ID="UpDatePanelFiltro" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>

                <%-- FILTRO ESTADO --%>
                <p>
                    Filtro por estado:
                    <asp:DropDownList runat="server" ID="ddlEstados" CssClass="btn btn-outine-dark drop-down-toggle" />
                    <asp:Button Text="Buscar" CssClass="btn btn-primary" runat="server" OnClick="btnFiltro_Click" />
                    <button type="button" class="btn btn-success" onclick="mostrarFechas()">Reporte de ventas por fecha</button>
                </p>
                <div>
                    <asp:Label runat="server" ID="MensajeError" Visible="false" Text="" CssClass="text-danger" Font-Bold="true"></asp:Label>
                </div>


                <%-- REPORTE VENTAS --%>
                <div class="row" id="contenedorFechas" style="display: none;">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="input-group date" id="FechaInicio">
                                <label for="startDate" class="input-group-prepend">
                                    <span class="input-group-text" style="background: white; height: 40px;">Fecha inicio:</span>
                                </label>
                                <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control datepicker" Style="background: white; height: 40px;" />
                                <div class="input-group-append">
                                    <span class="input-group-text" style="height: 40px;">
                                        <i class="fas fa-calendar-alt"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group date" id="FechaFin">
                                <label for="startDate" class="input-group-prepend">
                                    <span class="input-group-text" style="background: white; height: 40px;">Fecha fin:</span>
                                </label>
                                <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control datepicker" Style="background: white; height: 40px;" />
                                <div class="input-group-append">
                                    <span class="input-group-text" style="height: 40px;">
                                        <i class="fas fa-calendar-alt"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 d-flex align-items-center">
                            <asp:LinkButton Text="Buscar" CssClass="btn btn-primary" runat="server" OnClick="btnReporte_Click" />
                            <div class="form-check ml-3">
                                <asp:LinkButton Text="Limpiar filtro" CssClass="form-check-label" runat="server" OnClick="btnLimpiarFiltro_Click" />
                            </div>
                        </div>

                    </div>
                </div>


                <%-- LISTADO --%>
                <asp:GridView runat="server" ID="dgvVentas" DataKeyNames="Id"
                    CssClass="table table-hover table-light" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged"
                    OnPageIndexChanging="dgvVentas_PageIndexChanging"
                    AllowPaging="true" PageSize="5">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Fecha venta" DataField="FechaCompra" DataFormatString="{0:d}" />
                        <asp:BoundField HeaderText="Precio Total" DataField="PrecioTotal" DataFormatString="{0:C2}" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Detalle" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <style>
        .encabezado-tabla {
            display: flex;
        }

        .container {
            height: 500px;
            justify-content: center;
            padding: 10px;
            margin: 30px;
        }
    </style>


    <!-- Configuración del datepicker -->
    <script>


        flatpickr('.datepicker', {
            dateFormat: 'd/m/Y', // ajusta el formato según tus necesidades
            enableTime: false, // si deseas incluir la selección de hora

        });

        function mostrarFechas() {
            var contenedorFechas = document.getElementById('contenedorFechas');
            var txtStartDate = document.getElementById('<%= txtStartDate.ClientID %>');
            var txtEndDate = document.getElementById('<%= txtEndDate.ClientID %>');

            // Muestra el contenedor de fechas si está oculto
            if (contenedorFechas.style.display === 'none') {
                contenedorFechas.style.display = 'block';
            }

            // Reinicia los valores de los selectores de fecha
            txtStartDate.value = '';
            txtEndDate.value = '';

            // Llama a la función para inicializar el selector de fecha
            inicializarFlatpickr();
        }

        function inicializarFlatpickr() {
            flatpickr('.datepicker', {
                dateFormat: 'd/m/Y',
                enableTime: false,
                theme: 'light',
            });
        }

    </script>


</asp:Content>
