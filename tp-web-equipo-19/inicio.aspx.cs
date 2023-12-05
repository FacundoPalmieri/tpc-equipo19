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

        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;

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

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtBuscador.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Menor a ");
                ddlCriterio.Items.Add("Mayor a ");
            }
            else if (ddlCampo.SelectedItem.ToString() == "Todo")
            {
                ddlCriterio.Items.Clear();
                txtFiltroAvanzado.Text = "";
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con ");
                ddlCriterio.Items.Add("Termina con ");
                ddlCriterio.Items.Add("Contiene ");
            }
        }



        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articulo = new ArticuloNegocio();

                List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];

                if (ListaArticulos != null && ddlCampo.SelectedItem.ToString() != "Todo")
                {
                    List<Articulo> listaFiltrada = articulo.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                    Session["listaFiltrada"] = listaFiltrada;
                    Repetidor.DataSource = listaFiltrada;
                    Repetidor.DataBind();
                }
                else
                {
                    ListaArticulos = articulo.Listar();
                    Session.Add("listaArticulos", ListaArticulos);
                    Repetidor.DataSource = ListaArticulos;
                    Repetidor.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }


    }
}

