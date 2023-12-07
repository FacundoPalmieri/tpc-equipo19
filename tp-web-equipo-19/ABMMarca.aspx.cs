using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19
{
    public partial class ABMMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();
            dgvMarcas.DataSource = marca.listar();
            dgvMarcas.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("marca.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCuenta.aspx");
           
        }

      
        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("marca.aspx?Id=" + Id);
        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.PageIndex = e.NewPageIndex;
            dgvMarcas.DataBind();
        }

    }
}