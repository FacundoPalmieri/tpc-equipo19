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
    public partial class ABMCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            dgvCategorias.DataSource = categoria.listar();
            dgvCategorias.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoria.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCuenta.aspx");
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("categoria.aspx?Id=" + Id);
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategorias.PageIndex = e.NewPageIndex;
            dgvCategorias.DataBind();
        }
    }
}