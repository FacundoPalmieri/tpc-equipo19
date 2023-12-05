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
    public partial class DetalleVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtFechaVenta.Enabled = false;
            txtCostoEnvio.Enabled = false;
            txtCostoTotal.Enabled = false;

            txtIDUsuario.Enabled = false;
            txtNombreUsuario.Enabled=false;
            txtApellidoUsuario.Enabled = false;
            txtContactoUsuario.Enabled = false;
            txtMailUsuario.Enabled = false;

            try
            {
                string Id = Request.QueryString["Id"];


                if (Request.QueryString["Id"] != null && !IsPostBack)
                {

                    //Datos compra
                    Compra compra = new Compra();
                    CompraNegocio compraNegocio = new Negocio.CompraNegocio();
                    compra = compraNegocio.CompraPorID(int.Parse(Id));

                    txtID.Text = Id;
                    txtFechaVenta.Text = compra.FechaCompra.ToString("d");
                    txtCostoTotal.Text = compra.PrecioTotal.ToString();
                    txtCostoEnvio.Text = compra.CostoEnvio.ToString();

                    //Datos cliente
                    Usuario usuario = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    int IdUsuario = compra.IdUsuario;
                    usuario = usuarioNegocio.UsuarioPorID(IdUsuario);

                    txtIDUsuario.Text = IdUsuario.ToString();
                    txtNombreUsuario.Text = usuario.Nombre.ToString();
                    txtApellidoUsuario.Text = usuario.Apellido.ToString();
                    txtContactoUsuario.Text = usuario.Contacto.ToString();
                    txtMailUsuario.Text = usuario.User.ToString();

                    //datos detalle compra

                    DetalleCompraNegocio detalleCompraNegocio = new DetalleCompraNegocio();
                    List<DetalleCompra> Lista = detalleCompraNegocio.ListarPorID(int.Parse(Id));

                    RepeaterDetalleArticulos.DataSource = Lista;
                    RepeaterDetalleArticulos.DataBind();

                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Inicio.aspx");
                throw;
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Categoria categoria = new Categoria();
            //CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            //try
            //{
            //    //pre cargar datos modificar
            //    categoria.Descripcion = txtDescripcion.Text;

            //    if (Request.QueryString["Id"] != null)
            //    {
            //        categoria.Id = int.Parse(Request.QueryString["Id"].ToString());
            //        categoriaNegocio.Modificar(categoria);
            //    }
            //    else
            //        categoriaNegocio.Agregar(categoria);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            //List<Categoria> ListaCategorias = categoriaNegocio.listar();
            //Session["ListaCategorias"] = ListaCategorias;

            //Response.Redirect("ABMCategoria.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }
    }
}