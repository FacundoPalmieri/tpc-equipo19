using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace tp_web_equipo_19
{
    public partial class Carrito : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                MostrarCarrito();

                if (Session["Id"] != null)
                {
                    int id = (int)Session["Id"];

                    CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

                    if (miCarritoNegocio == null)
                    {
                        miCarritoNegocio = new CarritoNegocio();
                    }

                    bool articuloYaEnCarrito = miCarritoNegocio.listacarrito.Any(item => item.Articulo.Id == id);

                    if (!articuloYaEnCarrito)
                    {
                        List<Articulo> ListaArticulos;
                        ArticuloNegocio articulo = new ArticuloNegocio();
                        ListaArticulos = articulo.Listar();

                        Articulo seleccionado = ListaArticulos.Find(x => x.Id == id);

                        if (seleccionado != null)
                        {
                            miCarritoNegocio.Agregar(seleccionado, 1);
                            Session["IdArticuloSeleccionado"] = seleccionado.Id;
                        }

                    }
                    Session["Carrito"] = miCarritoNegocio;
                    RepeaterCarrito.DataSource = miCarritoNegocio.listacarrito;
                    RepeaterCarrito.DataBind();

                    decimal totalCarrito = miCarritoNegocio.CalcularTotalCarrito();

                    lblTotalCarrito.Text = totalCarrito.ToString("C");

                    Session["Id"] = null;

                    ActualizarCantidadArticulosEnCarrito();

                }
;
            }
        }


        protected void MostrarCarrito()
        {
            CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

            if (miCarritoNegocio != null)
            {
                RepeaterCarrito.DataSource = miCarritoNegocio.listacarrito;
                RepeaterCarrito.DataBind();
                decimal totalCarrito = miCarritoNegocio.CalcularTotalCarrito();
                lblTotalCarrito.Text = totalCarrito.ToString("C");
            }
        }

        

        private int ObtenerIndiceDelArticulo(int idArticulo)
        {
            CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

            if (miCarritoNegocio != null)
            {
                for (int i = 0; i < miCarritoNegocio.listacarrito.Count; i++)
                {
                    if (miCarritoNegocio.listacarrito[i].Articulo.Id == idArticulo)
                    {
                        return i;
                    }
                }
            }

            return -1; 
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            TextBox txtCantidad = (TextBox)sender;

            int idArticuloSeleccionado = Convert.ToInt32(Session["IdArticuloSeleccionado"]);

            
            CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

            
            if (miCarritoNegocio != null)
            {
          
                int nuevaCantidad;
                if (int.TryParse(txtCantidad.Text, out nuevaCantidad))
                {
                    
                    int indice = ObtenerIndiceDelArticulo(idArticuloSeleccionado);

                    if (indice >= 0 && indice < miCarritoNegocio.listacarrito.Count)
                    {
                        miCarritoNegocio.listacarrito[indice].Cantidad = nuevaCantidad;
                    }
                  
                    decimal totalCarrito= miCarritoNegocio.CalcularTotalCarrito();
                    lblTotalCarrito.Text = totalCarrito.ToString("C");
                    ActualizarCantidadArticulosEnCarrito();
                    MostrarCarrito();
                }
            }
        }

        protected void EliminarProducto_Click(object sender, EventArgs e)
        {
            int idArticuloSeleccionado = Convert.ToInt32(((Button)sender).CommandArgument);

            CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

            for (int i = 0; i < miCarritoNegocio.listacarrito.Count; i++)
            {
                if (miCarritoNegocio.listacarrito[i].Articulo.Id == idArticuloSeleccionado)
                {
                    miCarritoNegocio.listacarrito.RemoveAt(i);
                    break; // Importante salir del bucle después de eliminar el elemento
                }
            }

            decimal totalCarrito = miCarritoNegocio.CalcularTotalCarrito();

            lblTotalCarrito.Text = totalCarrito.ToString("C");
            ActualizarCantidadArticulosEnCarrito();
            Response.Redirect(Request.RawUrl);
            MostrarCarrito();
        }


        private void ActualizarCantidadArticulosEnCarrito()
        {
            CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

            if (miCarritoNegocio == null)
            {
                miCarritoNegocio = new CarritoNegocio();
            }

            int cantidadArticulosEnCarrito = miCarritoNegocio.listacarrito.Count;

            Session["CantidadArticulosEnCarrito"] = cantidadArticulosEnCarrito;
        }

        protected void ButtonCompra_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}