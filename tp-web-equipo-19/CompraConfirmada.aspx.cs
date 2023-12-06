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
                    int Comprobante = (int)Session["IdCompra"];
                     var usuarioEnSesion = Session["Usuario"] as Dominio.Usuario;
                     string Mail = usuarioEnSesion.User;
                     string Celular = usuarioEnSesion.Contacto;


                     // Asignar el valor al Label
                    LabelComprobante.Font.Bold = true;
                    lblComprobante.Text = Comprobante.ToString(); // Mostrar el valor en el Label
                    lblMail.Text = Mail.ToString();
                    lblCelular.Text = Celular.ToString();
            }
            

        }

        protected void ButtonContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}