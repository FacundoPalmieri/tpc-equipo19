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
    public partial class CompraConfirmada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Suponiendo que ya has obtenido el valor de Comprobante
                int Comprobante = (int)Session["IdCompra"];

                // Asignar el valor al Label
                lblComprobante.Text = Comprobante.ToString(); // Mostrar el valor en el Label
            }
        }
    }
}