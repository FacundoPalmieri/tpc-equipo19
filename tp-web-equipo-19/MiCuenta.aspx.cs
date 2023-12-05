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
    public partial class MiCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuario = Session["Usuario"] as Dominio.Usuario;

            if (usuario != null)
            {
                int Id = usuario.Id;

                usuario = usuarioNegocio.UsuarioPorID(Id);
                if (usuario.EsAdministrador())
                {
                    MisDatos.Visible = false;
                }



            }

        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Cierra la sesión actual
            Response.Redirect("inicio.aspx");
        }


        protected void MisDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }
    }
}