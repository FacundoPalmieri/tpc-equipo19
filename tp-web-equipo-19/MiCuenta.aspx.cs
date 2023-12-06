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
            int Id = new int();
            //Verifica si es administrador para que no pueda acceder y sea redirigido. 
            usuario = Session["Usuario"] as Dominio.Usuario;

            if (usuario != null)
            {
                Id = usuario.Id;
                usuario = usuarioNegocio.UsuarioPorID(Id);
                if (usuario.EsAdministrador())
                {

                    Response.Redirect("Inicio.aspx");

                }
            }

        }

        protected void MisDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }

        protected void MisCompras_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            int Id = new int();
            usuario = Session["Usuario"] as Dominio.Usuario;
            Id = usuario.Id;
            Response.Redirect("MisCompras.aspx?Id=" + Id);
        }
        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Cierra la sesión actual
            Response.Redirect("inicio.aspx");
        }


    }
}