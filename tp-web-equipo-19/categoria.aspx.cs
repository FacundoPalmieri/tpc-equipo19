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
    public partial class categoria : System.Web.UI.Page
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
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    Categoria seleccionado = categoriaNegocio.ListarPorID(int.Parse(Id))[0];

                    //pre cargar datos
                    txtID.Text = Id;
                    txtDescripcion.Text = seleccionado.Descripcion;
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("ABMcategoria.aspx");
                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                //pre cargar datos modificar
                categoria.Descripcion = txtDescripcion.Text;

                if (Request.QueryString["Id"] != null)
                {
                    categoria.Id = int.Parse(Request.QueryString["Id"].ToString());
                    categoriaNegocio.Modificar(categoria);
                }
                else
                    categoriaNegocio.Agregar(categoria);
            }
            catch (Exception)
            {
                throw;
            }

            List<Categoria> ListaCategorias = categoriaNegocio.listar();
            Session["ListaCategorias"] = ListaCategorias;

            Response.Redirect("ABMCategoria.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMcategoria.aspx");
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
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    categoriaNegocio.Eliminar(int.Parse(txtID.Text));
                    Response.Redirect("ABMCategoria.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }
    }
}