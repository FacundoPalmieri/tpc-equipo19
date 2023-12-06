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
    public partial class RecuperarContraseña2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonVolver4_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                Usuario CredencialesUsuario = new Usuario();
                RecuperarContraseñaNegocio recuperarContraseñaNegocio = new RecuperarContraseñaNegocio();
                if (!string.IsNullOrEmpty(TextBoxPassword1.Text) && !string.IsNullOrEmpty(TextBoxPassword2.Text))
                {
                    usuario.User = (string)Session["Usuario"];
                    usuario.Password = TextBoxPassword1.Text;

                    recuperarContraseñaNegocio.RestablecerCredenciales(usuario);

                    Session["usuario"] = Session["Usuario"];

                    Response.Redirect("RecuperarContraseña3.aspx");
    
                }
                else
                {
                    MensajeError.Text = "Campos incompletos y/o incorrectos";
                    MensajeError.Visible = true;
                }


            }
            catch (Exception)
            {

                throw;
            }
        
            
        }
    }
}