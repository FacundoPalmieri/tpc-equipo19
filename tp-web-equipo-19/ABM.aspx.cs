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

        protected void ABMArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMArticulo.aspx");
        }
    }
}