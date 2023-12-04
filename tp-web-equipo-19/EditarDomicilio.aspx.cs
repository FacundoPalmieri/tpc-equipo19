using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19
{
    public partial class EditarDomicilio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = true;
            if (!IsPostBack)
            {
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                DDLEditarPais.DataSource = domicilioNegocio.listarPaises();
                DDLEditarPais.DataBind();
                DDLEditarPais.Items.Insert(0, new ListItem("-- Seleccionar Pais --", ""));

                // Cargar las provincias solo una vez al cargar la página
                DDLEditarProvincia.DataSource = domicilioNegocio.listarProvincias();
                DDLEditarProvincia.DataTextField = "Nombre";
                DDLEditarProvincia.DataValueField = "Id";
                DDLEditarProvincia.DataBind();


                DDLEditarProvincia.Items.Insert(0, new ListItem("-- Seleccionar Provincia --", ""));


                // Permite mostrar "--Seleccionar ciudad--"
                //La lista real la carga desde el evento
                DDLEditarCiudad.DataSource = domicilioNegocio.listarCiudades(1);
                DDLEditarCiudad.DataBind();
                DDLEditarCiudad.Items.Insert(0, new ListItem("-- Seleccionar Ciudad --", ""));

            }
        }
  

        protected void DDLEditarPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLEditarProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdProvinciaSeleccionada;
            if (int.TryParse(DDLEditarProvincia.SelectedValue, out IdProvinciaSeleccionada))
            {
                DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                DDLEditarCiudad.DataSource = domicilioNegocio.listarCiudades(IdProvinciaSeleccionada);
                DDLEditarCiudad.DataBind();

                if (IdProvinciaSeleccionada != 2)
                {
                    DDLEditarCiudad.Items.Insert(0, new ListItem("-- Seleccionar Ciudad --", ""));

                }
            }


        }

        protected void DDLEditarCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckEditarDomicilioEnBase_CheckedChanged(object sender, EventArgs e)
        {
  


        }

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compra.aspx");

        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            bool ValidacionCalle = true;
            bool ValidacionAltura = true;
            bool ValidacionPiso = true;
            bool ValidacionDepto = true;
            if (!string.IsNullOrEmpty(DDLEditarPais.SelectedValue) &&
               !string.IsNullOrEmpty(DDLEditarProvincia.SelectedValue) &&
               !string.IsNullOrEmpty(DDLEditarCiudad.SelectedValue) &&
               !string.IsNullOrEmpty(TextBoxEditarCalle.Text) &&
               !string.IsNullOrEmpty(TextBoxEditarAltura.Text)
              )
            {
                Session["Pais"] = DDLEditarPais.SelectedValue;
                Session["Provincia"] = DDLEditarProvincia.SelectedItem.Text;
                Session["ProvinciaID"] = DDLEditarProvincia.SelectedValue;
                Session["Ciudad"] = DDLEditarCiudad.SelectedValue;

                string textoCalle = TextBoxEditarCalle.Text;

                // Expresión regular para validar letras y espacios
                Regex regex = new Regex(@"^[a-zA-Z\s]+$");

                if (regex.IsMatch(textoCalle))
                {

                    Session["Calle"] = textoCalle;
                    ValidacionCalle = true;
                }
                else
                {

                    MensajeError.Text = "La calle solo debe contener letras y/o espacios.";
                    MensajeError.Visible = true;
                    ValidacionCalle = false;
                }


                string valorAltura = TextBoxEditarAltura.Text;

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


                string valorPiso = TextBoxEditarPiso.Text.Trim(); // Eliminar espacios en blanco al principio y al final

                if (string.IsNullOrEmpty(valorPiso))
                {

                    Session["Piso"] = 0;
                    ValidacionPiso = true;
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


                string valorDepto = TextBoxEditarDepto.Text.Trim(); // Eliminar espacios en blanco al principio y al final

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


                if (ValidacionCalle && ValidacionAltura && ValidacionPiso && ValidacionDepto == true)
                {
                    Response.Redirect("Compra.aspx");

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