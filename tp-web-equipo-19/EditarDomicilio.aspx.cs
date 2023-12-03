using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
  

        protected void ButtonVolver_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSiguiente_Click(object sender, EventArgs e)
        {

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
    }
}