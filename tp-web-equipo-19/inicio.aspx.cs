using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_web_equipo_19
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        public int CantidadArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaArticulos"] == null)
            {
                ArticuloNegocio articulo = new ArticuloNegocio();
                ListaArticulos = articulo.Listar();
                Session.Add("listaArticulos", ListaArticulos);
            }

            if (!IsPostBack)
            {
                Repetidor.DataSource = Session["ListaArticulos"];
                Repetidor.DataBind();
            }
        }

        protected void btnAniadirAlCarrito_Click(object sender, EventArgs e)
        {
            string Valor = ((Button)sender).CommandArgument;
            if (int.TryParse(Valor, out int id))
            {
                Session["Id"] = id;
            }

            Response.Redirect("Carrito.aspx", false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscador.Text;

            List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];

            if (ListaArticulos != null)
            {
                List<Articulo> listaFiltrada = ListaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.CodigoArticulo.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));

                Session["listaFiltrada"] = listaFiltrada;
                Repetidor.DataSource = listaFiltrada;
                Repetidor.DataBind();
            }

        }

    }
}

