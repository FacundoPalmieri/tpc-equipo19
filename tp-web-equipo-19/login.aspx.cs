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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva(Session["Usuario"]))
            {
                Response.Redirect("MiCuenta.aspx");
            }
        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {

            Usuario usuario;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuario(TextBoxUser.Text, TextBoxPassword.Text, false);
                if (usuarioNegocio.Loguear(usuario))
                {
                    Session["Usuario"] = usuario;
                    if (((Usuario)Session["Usuario"]).TipoUsuario == TipoUsuario.Cliente)
                    {
                        Session.Add("Usuario", usuario);
                        Response.Redirect("inicio.aspx");

                    }
                    else
                    {
                        Session.Add("Usuario", usuario);
                        Response.Redirect("ABM.aspx");

                    }

                }
                else
                {
                    MensajeError.Text = "Usuario o Contraseña incorrecta";
                    MensajeError.Visible = true; // Hace visible el mensaje de error


                }
            }
            catch (Exception Ex)
            {
                Session.Add("Error", Ex.ToString());
            }

        }

        protected void ButtonRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}
