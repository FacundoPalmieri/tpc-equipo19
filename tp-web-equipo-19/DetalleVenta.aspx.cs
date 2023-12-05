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

            ddlEstado.Visible = false;
            txtEstado.Visible = true;
            btnGuardar.Visible = false;


            try
            {
                string Id = Request.QueryString["Id"];

                if (Request.QueryString["Id"] != null && !IsPostBack)
                {

                    //Datos compra
                    Compra compra = new Compra();
                    CompraNegocio compraNegocio = new Negocio.CompraNegocio();
                    compra = compraNegocio.CompraPorID(int.Parse(Id));

                    litID.Text = Id; 
                    litFechaVenta.Text = compra.FechaCompra.ToString("d"); 
                    litCostoEnvio.Text = compra.CostoEnvio.ToString("C2"); 
                    litCostoTotal.Text = compra.PrecioTotal.ToString("C2");


                    //Datos cliente
                    Usuario usuario = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    int IdUsuario = compra.IdUsuario;
                    usuario = usuarioNegocio.UsuarioPorID(IdUsuario);

                    litIDUsuario.Text = IdUsuario.ToString(); // Reemplaza con el valor real
                    litNombreUsuario.Text = usuario.Nombre.ToString(); // Reemplaza con el valor real
                    litApellidoUsuario.Text = usuario.Apellido.ToString();// Reemplaza con el valor real
                    litContactoUsuario.Text = usuario.Contacto.ToString(); // Reemplaza con el valor real
                    litMailUsuario.Text = usuario.User.ToString();


                    // Datos detalle compra
                    DetalleCompraNegocio detalleCompraNegocio = new DetalleCompraNegocio();
                    List<DetalleCompra> Lista = detalleCompraNegocio.ListarPorID(int.Parse(Id));

                    RepeaterDetalleVentas.DataSource = Lista;
                    RepeaterDetalleVentas.DataBind();

                    // Filtrar la segunda lista por IdArticulo de la primera lista
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    List<Articulo> listaArticulos = articuloNegocio.Listar();

                    List<Articulo> listaFiltrada = listaArticulos.Where(articulo => Lista.Any(detalle => detalle.IdArticulo == articulo.Id)).ToList();

                    RepeaterDetalleArticulos.DataSource = listaFiltrada;
                    RepeaterDetalleArticulos.DataBind();

                    //Estado de compra
                    if (!IsPostBack || Request.Form["__EVENTTARGET"] == ddlEstado.UniqueID) // ESTO HACE QUE SI SE RECARGUE LA PÁGINA NO ME PISE LE NUEVO ITEM SELECCION ADO EN ESTADO
                    { txtEstado.Text = compra.Estado.ToString(); }

                    //Forma de entrega
                    litFormaEnvio.Text = compra.MetodoEntrega.ToString();
                    litProvincia.Text = compra.Provincia.ToString();
                    litCalle.Text = compra.Calle.ToString();
                    litAltura.Text = compra.Altura.ToString();
                    litPiso.Text = compra.Depto.ToString();
                    litDepto.Text = compra.Depto.ToString();
                }
                

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Inicio.aspx");
                throw;
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // Oculta el TextBox en modo de edición
            txtEstado.Visible = false;

            // Muestra el DropDownList en modo de edición
            ddlEstado.Visible = true;

            //habilito botón guardar y oculto editar
            btnEditar.Visible = false;
            btnGuardar.Visible = true;
           

            EstadoCompraNegocio estado = new EstadoCompraNegocio();
            List<EstadoCompra> listaEstados = estado.listar();

            ddlEstado.DataSource = listaEstados;
            ddlEstado.DataValueField = "Id";
            ddlEstado.DataTextField = "Estado";
            ddlEstado.DataBind();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEstado.Text = ddlEstado.SelectedItem.Text;
            txtEstado.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Id = Request.QueryString["Id"];
            Compra compra = new Compra();
            CompraNegocio compraNegocio = new Negocio.CompraNegocio();
            compra = compraNegocio.CompraPorID(int.Parse(Id));
            compra.Estado = ddlEstado.SelectedItem.Text;
            compraNegocio.Modificar(compra);

            btnEditar.Visible = true;
            btnGuardar.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }

        protected string ObtenerNombreArticulo(int idArticulo, List<Articulo> listaArticulos)
        {
            Articulo articulo = listaArticulos.FirstOrDefault(a => a.Id == idArticulo);
            return articulo != null ? articulo.Nombre : string.Empty;
        }


    }
}