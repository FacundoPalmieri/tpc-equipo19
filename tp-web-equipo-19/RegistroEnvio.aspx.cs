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

                // Cargar las provincias solo una vez al cargar la página
                DDLProvincia.DataSource = domicilioNegocio.listarProvincias();
                DDLProvincia.DataTextField = "Nombre"; // Mostrar el nombre de la provincia
                DDLProvincia.DataValueField = "Id"; // Usar el ID de la provincia como valor
                DDLProvincia.DataBind();

                // Agregar un elemento en blanco para indicar selección
                DDLProvincia.Items.Insert(0, new ListItem("-- Seleccionar provincia --", ""));
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
            Response.Redirect("RegistroConfirmacion.aspx");
        }

    }
}