﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_web_equipo_19
{
    public partial class RegistroConfirmación : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           



        }

        protected void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxUser.Text) && !string.IsNullOrEmpty(TextBoxPassword1.Text) && !string.IsNullOrEmpty(TextBoxPassword2.Text) && !string.IsNullOrEmpty(TextBoxPalabraSeguridad.Text))
            {

                try
                {
                    Usuario usuario = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                    Domicilio domicilio = new Domicilio();
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();

                    string DatoNombre = Session["Nombre"].ToString();
                    usuario.Nombre = DatoNombre;

                    string DatoApellido = Session["Apellido"].ToString();
                    usuario.Apellido = DatoApellido;

                    string DatoTipoDocumento = Session["TipoDocumento"].ToString();
                    usuario.TipoDocumento = DatoTipoDocumento;

                    string DatoNDocumento = Session["NDocumento"].ToString();
                    usuario.NDocumento = DatoNDocumento;

                    string DatoContacto = Session["Celular"].ToString();
                    usuario.Contacto = DatoContacto;

                    String DatoPais = Session["Pais"].ToString();
                    domicilio.Pais = DatoPais;

                    String DatoProvincia = Session["Provincia"].ToString();
                    domicilio.Provincia = DatoProvincia;

                    String DatoCiudad = Session["Ciudad"].ToString();
                    domicilio.Ciudad = DatoCiudad;

                    String DatoCalle = Session["Calle"].ToString();
                    domicilio.Calle = DatoCalle;

                    if (Session["Altura"] != null && int.TryParse(Session["Altura"].ToString(), out int Altura))
                    {
                        // La conversión a entero fue exitosa
                        domicilio.Altura = Altura;
                    }

                    if (Session["Piso"] != null && int.TryParse(Session["Piso"].ToString(), out int Piso))
                    {
                        // La conversión a entero fue exitosa
                        domicilio.Piso = Piso.ToString();
                    }


                    String DatoDepto = Session["Depto"].ToString();
                    domicilio.Depto = DatoDepto;


                    string textoUsuario = TextBoxUser.Text;
                    if (textoUsuario.Contains("@"))
                    {
                        usuario.User = textoUsuario;
                    }
                    else
                    {

                        MensajeError.Text = "El usuario ingresado no parece ser un correo electrónico válido.";
                        MensajeError.Visible = true;
                    }

                    // Valida las contraseña y guarda en base

                    if(TextBoxPassword1.Text == TextBoxPassword2.Text)
                    {
                        usuario.Password = TextBoxPassword1.Text;
                        usuario.TipoUsuario = TipoUsuario.Cliente;
                        usuario.PalabraSeguridad = TextBoxPalabraSeguridad.Text;


                        int id = usuarioNegocio.RegistrarUsuario(usuario);
                        usuario.Id = id;

                        int IdDomicilio = domicilioNegocio.RegistrarDomicilio(domicilio, id);

                        Session.Add("Usuario", usuario);

                        Response.Redirect("Inicio.aspx");
                    }
                    else
                    {
                        MensajeError.Text = "Las contraseña deben coincidir";
                        MensajeError.Visible = true;

                    }

      
                    //usuario.User = TextBoxUser.Text;
                    //EmailService emailService = new EmailService();
                    //emailService.ArmarCorreo(usuario.User, "Bienvenido a FK Market", "Bienvenido");
                    //try
                    //{
                    //    emailService.EnviarMail();
                    //}
                    //catch (Exception Ex)
                    //{

                    //    Session.Add("error", Ex);
               
                 
              
                             
                }
                catch (Exception)
                {  
                    MensajeError.Text = "DNI y/o EMAIL, ya se encuentra registrado en la aplicación";
                    MensajeError.Visible = true; 
                }
            }
            else
            {
                MensajeError.Text = "Campos incompletos y/o incorrectos";
                MensajeError.Visible = true; 
            }

        }

        protected void ButtonVolver2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroEnvio.aspx");
        }
    }
}