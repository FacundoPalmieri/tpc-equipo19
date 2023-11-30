using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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

        bool ValidacionCalle = true;
        bool ValidacionAltura = true;
        bool ValidacionPiso = true;
        bool ValidacionDepto = true;
        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(DDLPais.SelectedValue) &&
               !string.IsNullOrEmpty(DDLProvincia.SelectedValue) &&
               !string.IsNullOrEmpty(DDLCiudad.SelectedValue) &&
               !string.IsNullOrEmpty(TextBoxCalle.Text) &&
               !string.IsNullOrEmpty(TextBoxAltura.Text)
              )
           { 
                Session["Pais"] = DDLPais.SelectedValue;
                Session["Provincia"] = DDLPais.SelectedValue;
                Session["Ciudad"] = DDLPais.SelectedValue;

                string textoCalle = TextBoxCalle.Text;

                // Expresión regular para validar letras y espacios
                Regex regex = new Regex(@"^[a-zA-Z\s]+$");

                if (regex.IsMatch(textoCalle))
                {
                    
                    Session["Calle"] = textoCalle;
                    ValidacionCalle = true;
                }
                else
                {
                    
                    MensajeError.Text = "La calle solo debe contener letras y espacios.";
                    MensajeError.Visible = true;
                    ValidacionCalle = false;
                }


                string valorAltura = TextBoxAltura.Text;

                if (int.TryParse(valorAltura, out int Altura))
                {
                   
                    Session["Altura"] = Altura;
                    ValidacionAltura = true;

                }
                else
                {
                  
                    MensajeError.Text = "La altura debe ser un número entero.";
                    MensajeError.Visible = true;
                    ValidacionAltura = false;
                }


                string valorPiso = TextBoxPiso.Text.Trim(); // Eliminar espacios en blanco al principio y al final

                if (string.IsNullOrEmpty(valorPiso))
                {
                   
                    Session["Piso"] = null; 
                    ValidacionPiso= true;
                }
                    // El valor del piso contiene como máximo dos dígitos y es un número entero válido
                else if (valorPiso.Length <= 2 && int.TryParse(valorPiso, out int Piso))
                {
                    Session["Piso"] = Piso;
                    ValidacionPiso = true;
                }
                else
                {
                 
                    MensajeError.Text = "El piso debe estar vacío o contener como máximo dos números enteros.";
                    MensajeError.Visible = true;
                    ValidacionPiso = false;
                }


                string valorDepto = TextBoxDepto.Text.Trim(); // Eliminar espacios en blanco al principio y al final

                // Expresión regular para validar si es solo una letra o dos números, pero no una combinación de ambos
                Regex regex1 = new Regex(@"^(?:[A-Za-z]|\d{1,2})$");

                if (string.IsNullOrEmpty(valorDepto))
                {
                    // El campo está vacío
                    Session["Depto"] = "-"; // Otra acción para indicar que el campo está vacío
                    ValidacionDepto = true;
                }
                else if (regex1.IsMatch(valorDepto))
                {
                    // El valor del depto cumple con el formato especificado
                    Session["Depto"] = valorDepto;
                    ValidacionDepto = true;
                }
                else
                {
                    // El valor del depto no cumple con el formato especificado
                    MensajeError.Text = "El campo 'Depto' debe contener como máximo dos números o una letra, pero no ambos.";
                    MensajeError.Visible = true;
                    ValidacionDepto = false;
                }


                if (ValidacionCalle && ValidacionAltura && ValidacionPiso && ValidacionDepto ==  true)
                {
                 Response.Redirect("RegistroConfirmacion.aspx");

                }

            }
            else
            {
                MensajeError.Text = "Campos incompletos y/o incorrectos";
                MensajeError.Visible = true; // Hace visible el mensaje de error
            }
        }

    }
}