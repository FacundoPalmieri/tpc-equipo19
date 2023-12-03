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
    public partial class compra : System.Web.UI.Page
    {
        
        public List<Domicilio> ListaDomicilio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarCarrito();

                // Verificar si hay un usuario en sesión
                if (Session["Usuario"] != null)
                {
                    var usuarioEnSesion = Session["Usuario"] as Dominio.Usuario;

                    if (usuarioEnSesion != null)
                    {
                        Dominio.Usuario usuarioNuevo = new Dominio.Usuario();
                        int Id = usuarioEnSesion.Id;

                        //Verificar lugar donde vive, para calcular envío 

                        DomicilioNegocio ProvinciaNegocio = new DomicilioNegocio();
                        TipoEnvioNegocio envioNegocio = new TipoEnvioNegocio();
                        int Provincia = new int();
                        decimal Envio = new decimal();

                        Provincia = ProvinciaNegocio.ConsultarProvincias(usuarioEnSesion.Id);



                    }

                }
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

        protected void lblCambioDomicilio_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");

        }
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ABM.aspx");
        }

        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (EnvioDomicilio.Checked)
            {
                decimal Envio = new decimal();
                Envio = costoEnvio();
                CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

                if (miCarritoNegocio != null)
                {
                    RepeaterCarrito.DataSource = miCarritoNegocio.listacarrito;
                    RepeaterCarrito.DataBind();
                    decimal totalCarrito = miCarritoNegocio.CalcularTotalCarrito();
                    totalCarrito += Envio;
                    lblTotalCarrito.Text = totalCarrito.ToString("C");
                    lblEnvio.Text = Envio.ToString("C");
                }
            }
            else
            {
                CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;

                if (miCarritoNegocio != null)
                {
                    decimal Envio = new decimal();
                    Envio = costoEnvio();
                    RepeaterCarrito.DataSource = miCarritoNegocio.listacarrito;
                    RepeaterCarrito.DataBind();
                    decimal totalCarrito = miCarritoNegocio.CalcularTotalCarrito();
                    lblTotalCarrito.Text = totalCarrito.ToString("C");
                    lblEnvio.Text = Envio.ToString("C");
                }

            }
        }

        protected decimal costoEnvio()
        {
            var usuarioEnSesion = Session["Usuario"] as Dominio.Usuario;

            DomicilioNegocio ProvinciaNegocio = new DomicilioNegocio();
            TipoEnvioNegocio envioNegocio = new TipoEnvioNegocio();
            int Provincia = new int();
            decimal Envio = new decimal();

            Provincia = ProvinciaNegocio.ConsultarProvincias(usuarioEnSesion.Id);

            if (!EnvioDomicilio.Checked)
            {
                Envio = envioNegocio.CostoEnvio(1);
            }
            else
            {
                if (Provincia == 2)
                {
                    Envio = envioNegocio.CostoEnvio(2);
                }
                else
                {
                    Envio = envioNegocio.CostoEnvio(3);
                }
            }

            return Envio;
        }

    }
}
