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
    public partial class RecuperarContraseña1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
          if (!string.IsNullOrEmpty(TextBoxUser.Text) && !string.IsNullOrEmpty(TextBoxPalabraSeguridad.Text))
          {
             Usuario usuario = new Usuario();
             Usuario CredencialesUsuario = new Usuario();
             RecuperarContraseñaNegocio recuperarContraseñaNegocio = new RecuperarContraseñaNegocio();

             usuario.User = TextBoxUser.Text;
             usuario.PalabraSeguridad = TextBoxPalabraSeguridad.Text;

             CredencialesUsuario = recuperarContraseñaNegocio.ConsultarCredenciales(usuario);

             if (usuario.PalabraSeguridad == CredencialesUsuario.PalabraSeguridad)
             {
                 Session["Usuario"] = usuario.User;
                 Response.Redirect("RecuperarContraseña2.aspx");

             }
             else
             {
                 MensajeError.Text = "Palabra de seguridad incorrecta";
                 MensajeError.Visible = true;

             }
          }
          else
          {
            MensajeError.Text = "Campos incompletos y/o incorrectos";
            MensajeError.Visible = true;
          }

        }

        protected void ButtonVolver3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}