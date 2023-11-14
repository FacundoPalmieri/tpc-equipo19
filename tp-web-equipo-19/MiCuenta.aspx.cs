using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("loguin.aspx");
            }

        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Cierra la sesión actual
            Response.Redirect("inicio.aspx");
        }
    }
}