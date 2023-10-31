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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarCantidadArticulosEnCarrito();
            }

        }


        private void ActualizarCantidadArticulosEnCarrito()
        {
            if (Session["CantidadArticulosEnCarrito"] != null)
            {
                int cantidadArticulosEnCarrito = (int)Session["CantidadArticulosEnCarrito"];
                lblCantidadArticulos.Text = cantidadArticulosEnCarrito.ToString();
            }
            else
            {
                lblCantidadArticulos.Text = "0";
            }
        }

    }
}