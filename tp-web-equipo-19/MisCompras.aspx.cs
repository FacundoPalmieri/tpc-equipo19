using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19
{
    public partial class MisCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdUsuario = int.Parse(Request.QueryString["Id"]);
            CompraNegocio compras = new CompraNegocio();
            dgvVentas.DataSource = compras.filtrarPorUsuario(IdUsuario).OrderByDescending(x => x.FechaCompra).ToList();
            dgvVentas.DataBind();

            List<Compra> listaCompras = compras.filtrarPorUsuario(IdUsuario);
            Session.Add("listaCompras", listaCompras);

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiCuenta.aspx");
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