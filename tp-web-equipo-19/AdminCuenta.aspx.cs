using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dominio;
using Negocio;

namespace tp_web_equipo_19
{
    public partial class ABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Ventas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }

        protected void ABMArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMArticulo.aspx");
        }

        protected void ABMCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMCategoria.aspx");
        }

        protected void ABMMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMMarca.aspx");
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Cierra la sesión actual
            Response.Redirect("inicio.aspx");
        }

    }
}