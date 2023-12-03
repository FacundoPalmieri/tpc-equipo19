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
                       

                        Provincia = ProvinciaNegocio.ConsultarProvincias(usuarioEnSesion.Id);



                        Domicilio domicilio = new Domicilio();
                        if (Session["Pais"]  == null)
                        {
                            DomicilioNegocio domicilioNegocio = new DomicilioNegocio(); 
                            ListaDomicilio = domicilioNegocio.DomicilioUsuario(Id);
                            domicilio = ListaDomicilio.LastOrDefault();
                            Repeater1.DataSource = ListaDomicilio;
                            Repeater1.DataBind();
                            

                        }
                        else
                        {
                           domicilio.Pais = Session["Pais"].ToString();
                           domicilio.Provincia = Session["Provincia"].ToString();
                           domicilio.Ciudad = Session["Ciudad"].ToString();
                           domicilio.Calle = Session["Calle"].ToString();
                           int altura;
                           if (int.TryParse(Session["Altura"].ToString(), out altura))
                           {
                            domicilio.Altura = altura; // Asigna la altura convertida a domicilio.Altura
                           }
                           domicilio.Piso = Session["Piso"].ToString() ;
                           domicilio.Depto = Session["Depto"].ToString();
                        }
                        List<Domicilio> listaDomicilio = new List<Domicilio> { domicilio };
                        Repeater1.DataSource = listaDomicilio;
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
                if (Session["Pais"] == null)
                {
                    Envio = costoEnvio();

                }
                else
                {
                    int IdProvincia = Convert.ToInt32(Session["ProvinciaID"]);
                    Envio = costoEnvio(IdProvincia);
                }






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

        protected decimal costoEnvio(int Id )
        {
            var usuarioEnSesion = Session["Usuario"] as Dominio.Usuario;

            DomicilioNegocio ProvinciaNegocio = new DomicilioNegocio();
            TipoEnvioNegocio envioNegocio = new TipoEnvioNegocio();
            //int Provincia = new int();
            decimal Envio = new decimal();

            //Provincia = ProvinciaNegocio.ConsultarProvincias(usuarioEnSesion.Id);

            if (!EnvioDomicilio.Checked)
            {
                Envio = envioNegocio.CostoEnvio(1);
            }
            else
            {
                if (Id == 2)
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
            CompraNegocio compraNegocio = new Negocio.CompraNegocio();
            Compra compra = new Compra();
            CarritoNegocio carritoNegocio = new CarritoNegocio();
            var usuarioEnSesion = Session["Usuario"] as Dominio.Usuario;
            Carrito carrito = new Carrito();
            Domicilio domicilio = new Domicilio();
            int Id = usuarioEnSesion.Id;


            if (EnvioDomicilio.Checked || retiroLocal.Checked)
            {
                MensajeError.Visible = false;


                string script = "var nuevaVentana = window.open('CompraConfirmada.aspx', '_blank', 'width=600,height=400');" +
                                "nuevaVentana.focus();" +
                                "window.addEventListener('message', function(event) {" +
                                "    if (event.data === 'clicEnVentanaEmergente') {" +
                                "        window.location.href = 'inicio.aspx';" + // Redirigir a la nueva página
                                "    }" +
                                "});"; // Reemplaza 'NuevaPagina.aspx' con la URL deseada
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", script, true);


                //Guardo en base de datos
                
       
                compra.IdUsuario = usuarioEnSesion.Id;
                compra.PrecioTotal = decimal.Parse(lblTotalCarrito.Text); ///// REVISAR
                compra.FechaCompra = DateTime.Now;
                compra.Estado = "Pendiente de pago";
                if (Session["Pais"] == null)
                {
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                    ListaDomicilio = domicilioNegocio.DomicilioUsuario(Id);
                    domicilio = ListaDomicilio.LastOrDefault();
                    compra.Pais = domicilio.Pais;
                    compra.Provincia = domicilio.Provincia;
                    compra.Ciudad = domicilio.Ciudad;
                    compra.Calle = domicilio.Calle;
                    compra.Altura = domicilio.Altura;
                    compra.Piso = domicilio.Piso;
                    compra.Depto = domicilio.Depto;
                }
                else
                {
                    compra.Pais = Session["Pais"].ToString();
                    compra.Provincia = Session["Provincia"].ToString();
                    compra.Ciudad = Session["Ciudad"].ToString();
                    compra.Calle = Session["Calle"].ToString();
                    int altura;
                    if (int.TryParse(Session["Altura"].ToString(), out altura))
                    {
                        domicilio.Altura = altura; // Asigna la altura convertida a domicilio.Altura
                    }
                    compra.Piso = Session["Piso"].ToString();
                    compra.Depto = Session["Depto"].ToString();


                }

                int IdCompra = compraNegocio.AgregarCompra(compra);
                Session["IdCompra"] = IdCompra;

                //Limpio articulos en carrito y cantidad en el icono.
                Session["Carrito"] = null;
                carrito.ActualizarCantidadArticulosEnCarrito(0);
            }
            else
            {
                    MensajeError.Text = "Debe seleccionar método de entrega";
                    MensajeError.Visible = true;
            }

       











        }
    }
}
