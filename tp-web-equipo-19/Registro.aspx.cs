using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace tp_web_equipo_19
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                TipoDocumentoNegocio tipoDocumentoNegocio = new TipoDocumentoNegocio();
                DDLTipoDni.DataSource = tipoDocumentoNegocio.listarTiposDocumentos();
                DDLTipoDni.DataValueField = "Nombre";
                DDLTipoDni.DataBind();

                DDLTipoDni.Items.Insert(0, new ListItem("--Seleccionar Tipo-", ""));
            }
        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            if (((!string.IsNullOrEmpty(TextBoxNombre.Text) &&
                !string.IsNullOrEmpty (TextBoxApellido.Text) && 
                !string.IsNullOrEmpty(TextBoxDNI.Text) &&
                !string.IsNullOrEmpty(TextBoxContacto.Text)) &&
                (DDLTipoDni.SelectedValue)!=null)
                )
                
                
            {
                Session["Nombre"] = TextBoxNombre.Text;
                Session["Apellido"] = TextBoxApellido.Text;
                Session["TipoDocumento"] = DDLTipoDni.SelectedValue;
                Session["NDocumento"] = TextBoxDNI.Text;


                string numeroContacto = TextBoxContacto.Text;

                // Patrón para verificar que solo se ingresen dígitos (0-9)
                Regex regex = new Regex(@"^[0-9]+$");


                if (regex.IsMatch(numeroContacto))
                {
              
                    Session["Celular"] = numeroContacto;
                    Response.Redirect("RegistroEnvio.aspx");
                }
                else
                {
                  
                    MensajeError.Text = "El campo 'Celular' Solo debe contener números";
                    MensajeError.Visible = true; 
                }


            }
            else
            {
                MensajeError.Text = "Campos incompletos y/o incorrectos";
                MensajeError.Visible = true; // Hace visible el mensaje de error
            }
        }

        protected void DDLTipoDni_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}