using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace tp_web_equipo_19
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ventas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }
        protected void ABM_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}