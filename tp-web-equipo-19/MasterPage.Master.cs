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
     
            if (!(Page is Default  || Page is Carrito || Page is login || Page is Registro || Page is RegistroEnvio || Page is RegistroConfirmación || Page is RecuperarContraseña1 || Page is RecuperarContraseña2 || Page is RecuperarContraseña3))
            {
                if (!Seguridad.SesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("login.aspx");
                }

            }

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