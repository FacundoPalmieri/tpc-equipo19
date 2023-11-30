using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19
{
    public partial class RegistroEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = true;
            if (!IsPostBack)
            {
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                DDLPais.DataSource = domicilioNegocio.listarPaises();
                DDLPais.DataBind();
                DDLPais.Items.Insert(0, new ListItem("-- Seleccionar Pais --", ""));

                // Cargar las provincias solo una vez al cargar la página
                DDLProvincia.DataSource = domicilioNegocio.listarProvincias();
                DDLProvincia.DataTextField = "Nombre"; 
                DDLProvincia.DataValueField = "Id"; 
                DDLProvincia.DataBind();

              
                DDLProvincia.Items.Insert(0, new ListItem("-- Seleccionar Provincia --", ""));


                // Permite mostrar "--Seleccionar ciudad--"
                //La lista real la carga desde el evento
                DDLCiudad.DataSource = domicilioNegocio.listarCiudades(1);
                DDLCiudad.DataBind();
                DDLCiudad.Items.Insert(0, new ListItem("-- Seleccionar Ciudad --", ""));
            }



        }
        protected void Pais_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        protected void DDLProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            int IdProvinciaSeleccionada;
            if (int.TryParse(DDLProvincia.SelectedValue, out IdProvinciaSeleccionada))
            {
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                DDLCiudad.DataSource = domicilioNegocio.listarCiudades(IdProvinciaSeleccionada);
                DDLCiudad.DataBind();

                if(IdProvinciaSeleccionada != 2)
                {
                     DDLCiudad.Items.Insert(0, new ListItem("-- Seleccionar Ciudad --", ""));

                }
            }


        }
        protected void DDLCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
    

        }
        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(DDLPais.SelectedValue) &&
               !string.IsNullOrEmpty(DDLProvincia.SelectedValue) &&
               !string.IsNullOrEmpty(DDLCiudad.SelectedValue) &&
               !string.IsNullOrEmpty(TextBoxCalle.Text) &&
               !string.IsNullOrEmpty(TextBoxAltura.Text) &&
               !string.IsNullOrEmpty(TextBoxPiso.Text) &&
               !string.IsNullOrEmpty(TextBoxDepto.Text)
              )
           { 
                Session["Pais"] = DDLPais.SelectedValue;
                Session["Provincia"] = DDLPais.SelectedValue;
                Session["Ciudad"] = DDLPais.SelectedValue;
                Session["Calle"] = TextBoxCalle.Text;
                int Altura;
                if (int.TryParse(TextBoxAltura.Text, out Altura))
                {

                    Session["Altura"] = Altura;
                }

                int Piso;
                if (int.TryParse(TextBoxPiso.Text, out Piso))
                {
                    Session["Piso"] = Piso;
                }

                Session["Depto"] = TextBoxDepto.Text;

                Response.Redirect("RegistroConfirmacion.aspx");
            }
            else
            {
                MensajeError.Text = "Campos incompletos y/o incorrectos";
                MensajeError.Visible = true; // Hace visible el mensaje de error
            }
        }

    }
}