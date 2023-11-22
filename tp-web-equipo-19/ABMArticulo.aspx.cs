using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
namespace tp_web_equipo_19
{
    public partial class ABMArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();
            dgvArticulos.DataSource = articulo.Listar();
            dgvArticulos.DataBind();
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("articulo.aspx");

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("articulo.aspx?Id=" + Id);
        }

        //protected void dgv_SelectedIndexChange(object sender, EventArgs e)
        //{
        //    var id = dgvArticulos.SelectedDataKey.Values.ToString();
        //}

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }


    }
}