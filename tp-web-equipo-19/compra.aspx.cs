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



                        DomicilioNegocio domicilioNegocio = new DomicilioNegocio(); 
                        Domicilio domicilio = new Domicilio();
                        ListaDomicilio = domicilioNegocio.DomicilioUsuario(Id);
                        domicilio = ListaDomicilio.LastOrDefault();
                        Repeater1.DataSource = ListaDomicilio;
                        Repeater1.DataBind();


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



        protected void EditarDomicilio_Click1(object sender, EventArgs e)
        {
            Response.Redirect("EditarDomicilio.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");

        }
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            Carrito carrito = new Carrito();
           

            string script = "var nuevaVentana = window.open('CompraConfirmada.aspx', '_blank', 'width=600,height=400');" +
                            "nuevaVentana.focus();" +
                            "window.addEventListener('message', function(event) {" +
                            "    if (event.data === 'clicEnVentanaEmergente') {" +
                            "        window.location.href = 'inicio.aspx';" + // Redirigir a la nueva página
                            "    }" +
                            "});"; // Reemplaza 'NuevaPagina.aspx' con la URL deseada
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", script, true);
            
           

        }
    }
}
