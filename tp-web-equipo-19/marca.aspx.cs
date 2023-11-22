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
    public partial class marca : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            ConfirmaEliminacion = false;

            try
            {
                if (!IsPostBack)
                {



                }

                //Configuración modificar artículo

                string Id = Request.QueryString["Id"];


                if (Request.QueryString["Id"] != null && !IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    Marca seleccionado = marcaNegocio.ListarPorID(int.Parse(Id))[0];

                    //pre cargar datos
                    txtID.Text = Id;
                    txtDescripcion.Text = seleccionado.Descripcion;
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("ABMMarca.aspx");
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                //pre cargar datos modificar
                marca.Descripcion = txtDescripcion.Text;

                if (Request.QueryString["Id"] != null)
                {
                    marca.Id = int.Parse(Request.QueryString["Id"].ToString());
                    marcaNegocio.Modificar(marca);
                }
                else
                    marcaNegocio.Agregar(marca);
            }
            catch (Exception)
            {
                throw;
            }

            List<Marca> ListaMarcas = marcaNegocio.listar();
            Session["ListaMarcas"] = ListaMarcas;

            Response.Redirect("ABMMarca.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMMarca.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    marcaNegocio.Eliminar(int.Parse(txtID.Text));
                    Response.Redirect("ABMMarca.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }
    }
}
