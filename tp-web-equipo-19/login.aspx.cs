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

                        Response.Redirect("AdminCuenta.aspx");

                    }
                    else
                    {
                        Response.Redirect("MiCuenta.aspx");
                    }
                }
              
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
                    //Session["Usuario"] = usuario;
                    if (usuario.TipoUsuario == TipoUsuario.Cliente)
                    {
                        Usuario usuarioAux = new Usuario();
                        UsuarioNegocio usuarioNegocioAux = new UsuarioNegocio();

                        usuarioAux = usuarioNegocioAux.UsuarioPorID(usuario.Id);

                        Session.Add("Usuario", usuarioAux);
                        Response.Redirect("inicio.aspx");

                    }
                    else
                    {
                        Session.Add("Usuario", usuario);
                        Response.Redirect("AdminCuenta.aspx");

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

    

        protected void RecuperarContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecuperarContraseña1.aspx");

        }
    }
}
