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

                //Carga medios de pago

                MedioPagoNegocio medioPagoNegocio = new MedioPagoNegocio();
                List<MedioPago> listaMediosPago = medioPagoNegocio.listar();

                ddlMedioPago.DataSource = listaMediosPago;
                ddlMedioPago.DataTextField = "Nombre";
                ddlMedioPago.DataBind();
                ddlMedioPago.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

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
            decimal Envio = new decimal();

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


        protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");

        }


        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            CompraNegocio compraNegocio = new Negocio.CompraNegocio();
            Compra compra = new Compra();
            DetalleCompraNegocio detalleCompraNegocio = new DetalleCompraNegocio();
            CarritoNegocio miCarritoNegocio = Session["Carrito"] as CarritoNegocio;
            Carrito carrito = new Carrito();
            Domicilio domicilio = new Domicilio();
            DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            //Guardo información de usuario en sessión.
            var usuarioEnSesion = Session["Usuario"] as Dominio.Usuario;
            int Id = usuarioEnSesion.Id;

            ////Busco la información en BD que falta en la sessión de usuario
            //usuario=usuarioNegocio.UsuarioPorID(Id);

            ////asigno a la variable lo que traje de la BD
            //usuarioEnSesion.Contacto = usuario.Contacto;
            
            ////Asigno a la sessión los datos para pasarlo a CompraConfirmada.aspx
            //Session["Mail"] = usuarioEnSesion.User;
            //Session["Celular"] = usuarioEnSesion.Contacto.ToString();


           
            if ((EnvioDomicilio.Checked || retiroLocal.Checked) && !string.IsNullOrEmpty(ddlMedioPago.SelectedValue))
            {
                MensajeError.Visible = false;


                //Guardo en base de datos
       
                compra.IdUsuario = usuarioEnSesion.Id;
                compra.FechaCompra = DateTime.Now;
                compra.Estado = "Pendiente de pago";
                compra.PrecioVenta = miCarritoNegocio.CalcularTotalCarrito();
                compra.MedioPago = ddlMedioPago.SelectedItem.Text;
                if (EnvioDomicilio.Checked)
                {
                    compra.MetodoEntrega = "Envio a Domicilio";

                    if (Session["Pais"] == null) //SI EL PAIS NO ESTÁ EN SESSION, ES PORQUE ELIJO EL DOMICILIO YA CARGADO
                    { 
                        ListaDomicilio = domicilioNegocio.DomicilioUsuario(Id);
                        domicilio = ListaDomicilio.LastOrDefault();
                        compra.CostoEnvio = costoEnvio();
                        compra.PrecioTotal = (miCarritoNegocio.CalcularTotalCarrito()+costoEnvio());
                        compra.Pais = domicilio.Pais;
                        compra.Provincia = domicilio.Provincia;
                        compra.Ciudad = domicilio.Ciudad;
                        compra.Calle = domicilio.Calle;
                        compra.Altura = domicilio.Altura;
                        compra.Piso = domicilio.Piso;
                        compra.Depto = domicilio.Depto;
                    }
                    else //SI CARGA UNA DIRECCIÓN NUEVA
                    {
                        int IdProvincia = Convert.ToInt32(Session["ProvinciaID"]);
                         compra.CostoEnvio = costoEnvio(IdProvincia);
                         compra.PrecioTotal = (miCarritoNegocio.CalcularTotalCarrito() + costoEnvio(IdProvincia));
                        //compra.MedioPago = ddlMedioPago.SelectedItem.Text;
                        compra.Pais = Session["Pais"].ToString();
                        compra.Provincia = Session["Provincia"].ToString();
                        compra.Ciudad = Session["Ciudad"].ToString();
                        compra.Calle = Session["Calle"].ToString();
                        int altura;
                        if (int.TryParse(Session["Altura"].ToString(), out altura))
                        {
                           compra.Altura = altura; // Asigna la altura convertida a domicilio.Altura
                        }
                        compra.Piso = Session["Piso"].ToString();
                        compra.Depto = Session["Depto"].ToString();

                        bool Actualizar = false;
                        // Verificar si Session["ActualizarDomicilio"] no es nulo y tiene un valor válido
                        if (Session["ActualizarDomicilio"] != null && Session["ActualizarDomicilio"] is bool)
                        {
                            Actualizar = (bool)Session["ActualizarDomicilio"];

                            if (Actualizar)
                            {

                                domicilioNegocio.ActualizarDomicilio(compra, Id);


                                Actualizar = false;


                                Session["ActualizarDomicilio"] = Actualizar;
                            }
                        }
                    }
                    
                }
                else
                {
                    compra.MetodoEntrega = "Retiro en local";
                    compra.CostoEnvio = 0;
                    compra.PrecioTotal = (miCarritoNegocio.CalcularTotalCarrito() + costoEnvio());
                    compra.Pais = "-";
                    compra.Provincia = "-";
                    compra.Ciudad = "-";
                    compra.Calle = "-";
                    compra.Altura = 0;
                    compra.Piso = "-";
                    compra.Depto = "-";
                }

                int IdCompra = compraNegocio.AgregarCompra(compra);
                detalleCompraNegocio.AgregarCompra(miCarritoNegocio.listacarrito, IdCompra);

                Session["IdCompra"] = IdCompra;

           



                //Limpio articulos en carrito y cantidad en el icono.
                Session["Carrito"] = null;
                Session["Pais"] = null;

                carrito.ActualizarCantidadArticulosEnCarrito(0);
                Response.Redirect("CompraConfirmada.aspx");
            }
            else
            {
                    MensajeError.Text = "Debe seleccionar método de entrega y medios de pago";
                    MensajeError.Visible = true;
            }

        }

    }
}
