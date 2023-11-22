using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_web_equipo_19
{
    public partial class articulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            MostrarImagenPredeterminada();
            ConfirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    //Configuración artículo nuevo 

                    CategoriaNegocio categoria = new CategoriaNegocio();
                    List<Categoria> listaCategoria = categoria.listar();

                    MarcaNegocio marca = new MarcaNegocio();
                    List<Marca> listaMarca = marca.listar();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }

                //Configuración modificar artículo

                string Id = Request.QueryString["Id"];

                if (Request.QueryString["Id"] != null && !IsPostBack)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo seleccionado = articuloNegocio.ListarPorID(int.Parse(Id))[0];

                    //pre cargar datos
                    txtID.Text = Id;
                    txtCodigoArticulo.Text = seleccionado.CodigoArticulo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    
                    //pre cargar los desplegables

                    ddlMarca.SelectedValue = seleccionado.marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.Id.ToString();

                    //txtImagen.Text = seleccionado.imagen.ImagenUrl; no muestro el link, lo dejo vacío si quiere ingresar uno nuevo

                }
            }

            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("ABMArticulo.aspx");
                throw;
            }
        }

        private void MostrarImagenPredeterminada()
        {
            string urlPredeterminada = "https://cdn.pixabay.com/photo/2017/01/25/17/35/picture-2008484_1280.png";
            imgArticulo.ImageUrl = urlPredeterminada;
        }


        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            // Obtén la nueva URL de la imagen desde el TextBox
            string nuevaUrlImagen = TextBoxURL.Text;
            imgArticulo.ImageUrl = nuevaUrlImagen;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            Imagen imagen = new Imagen();
            Articulo articulo = new Articulo();

            try
            {
                articulo.CodigoArticulo = txtCodigoArticulo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articulo.marca = new Marca();
                articulo.marca.Id = int.Parse(ddlMarca.SelectedValue);

                articulo.categoria = new Categoria();
                articulo.categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    articulo.Id = int.Parse(Request.QueryString["Id"].ToString());
                    articuloNegocio.Modificar(articulo);
                }
                else
                    articuloNegocio.Agregar(articulo);

                imagen.ImagenUrl = TextBoxURL.Text;
            }

            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }


            int id;
            id = articuloNegocio.BuscarId(articulo);

            if (TextBoxURL.Text != "")
                imagenNegocio.Agregar(imagen.ImagenUrl, id);

            List<Articulo> ListaArticulos = articuloNegocio.Listar();
            Session["ListaArticulos"] = ListaArticulos;

            Response.Redirect("ABMArticulo.aspx", false);
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABMArticulo.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;

        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmaEliminacion.Checked)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    articuloNegocio.Eliminar(int.Parse(txtID.Text));
                    Response.Redirect("ABMArticulo.aspx");
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }
    }
}