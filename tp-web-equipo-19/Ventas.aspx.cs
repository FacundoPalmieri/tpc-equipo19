using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "inicializarFlatpickr", "inicializarFlatpickr();", true);

            CompraNegocio Ventas = new CompraNegocio();
            dgvVentas.DataSource = Ventas.listar().OrderByDescending(x => x.FechaCompra).ToList();
            dgvVentas.DataBind();

            List<Compra> listaCompras = Ventas.listar();
            Session.Add("listaCompras", listaCompras);

            if (!IsPostBack)
            {
                //Filtro estado

                EstadoCompraNegocio estadoCompraNegocio = new EstadoCompraNegocio();
                List<EstadoCompra> listaEstados = estadoCompraNegocio.listar();

                //Agrego a las opciones el valor 'Todas'
                EstadoCompra estadoCompra = new EstadoCompra();
                estadoCompra.Id = 0;
                estadoCompra.Estado = "Todas";
                listaEstados.Insert(0, estadoCompra);

                ddlEstados.DataSource = listaEstados;
                ddlEstados.DataValueField = "Id";
                ddlEstados.DataTextField = "Estado";
                ddlEstados.DataBind();
            }
        }


        protected void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {  // Captura los valores de las fechas de los controles TextBox
                DateTime fechaInicio = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaFin = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (fechaInicio < fechaFin)
                {
                    // Llama al método de CompraNegocio para realizar el filtrado
                    CompraNegocio compraNegocio = new CompraNegocio();
                    List<Compra> reporte = compraNegocio.Reporte(fechaInicio, fechaFin);

                    // Puedes hacer algo con la lista de compras filtradas, como mostrarla en un GridView o realizar alguna operación adicional.

                    dgvVentas.DataSource = reporte;
                    dgvVentas.DataBind();

                    Session["reporte"] = compraNegocio.Reporte(fechaInicio, fechaFin).OrderByDescending(x => x.FechaCompra).ToList();
                    UpDatePanelFiltro.Update();

                }
                else
                {
                    MensajeError.Text = "'Fecha Desde' no puede menor que 'Fecha Hasta'.";
                    MensajeError.Visible = true;
                }

            }
            catch (Exception)
            {
                MensajeError.Text = "Los campos 'Fecha Desde' y 'Fecha Hasta' no pueden estar vacios";
                MensajeError.Visible = true;

               
            }

          
        }


        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            CompraNegocio compra = new CompraNegocio();
            dgvVentas.DataSource = compra.listar().OrderByDescending(x => x.FechaCompra).ToList();
            dgvVentas.DataBind();

            Session["listaCompras"] = compra.listar().OrderByDescending(x => x.FechaCompra).ToList();
            UpDatePanelFiltro.Update();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                List<Compra> listaCompras = (List<Compra>)Session["listaCompras"];

                if (listaCompras != null)
                {
                    string estadoSeleccionado = ddlEstados.SelectedItem.Text;

                    if (estadoSeleccionado != "Todas")
                    {
                        CompraNegocio compra = new CompraNegocio();
                        List<Compra> listaFiltrada = compra.filtrar(estadoSeleccionado);
                        Session["listaCompras"] = listaFiltrada;
                        dgvVentas.DataSource = listaFiltrada.OrderByDescending(x => x.FechaCompra).ToList();
                        dgvVentas.DataBind();
                        UpDatePanelFiltro.Update();
                    }
                    else
                    {
                        CompraNegocio compra = new CompraNegocio();
                        dgvVentas.DataSource = compra.listar().OrderByDescending(x => x.FechaCompra).ToList();
                        dgvVentas.DataBind();

                        Session["listaCompras"] = compra.listar().OrderByDescending(x => x.FechaCompra).ToList();
                        UpDatePanelFiltro.Update();
                    }
                }
                else
                {
                    CompraNegocio compra = new CompraNegocio();
                    dgvVentas.DataSource = compra.listar().OrderByDescending(x => x.FechaCompra).ToList();
                    dgvVentas.DataBind();

                    Session["listaCompras"] = compra.listar().OrderByDescending(x => x.FechaCompra).ToList();
                    UpDatePanelFiltro.Update();
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }


        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvVentas.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleVenta.aspx?Id=" + Id);
        }

        protected void dgvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvVentas.PageIndex = e.NewPageIndex;
            dgvVentas.DataBind();
        }
    }
}