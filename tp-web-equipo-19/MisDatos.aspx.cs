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
        public partial class MisDatos : System.Web.UI.Page
        {
          
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    List<Domicilio> domicilios = new List<Domicilio>();
                    Domicilio domicilio = new Domicilio();  
                    DomicilioNegocio domicilioNegocio = new DomicilioNegocio();
                    Usuario usuario = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    int Id = new int();

   
                    //Verifica si es administrador para que no pueda acceder y sea redirigido. 
                    usuario = Session["Usuario"] as Dominio.Usuario;

                    if (usuario != null)
                    {
                        Id = usuario.Id;
                        usuario = usuarioNegocio.UsuarioPorID(Id);
                        if (usuario.EsAdministrador())
                        {

                            Response.Redirect("Inicio.aspx");

                        }
                    }

                    // Bloquea campos de texto para que no sean editables.
                    txtNombres.Enabled = false;
                    txtApellidos.Enabled = false;
                    txtDNI.Enabled = false;
                    txtProvincia.Enabled = false;
                    txtCiudad.Enabled = false;
                    txtCalle.Enabled = false;
                    txtAltura.Enabled = false;
                    txtPiso.Enabled = false;
                    txtDpto.Enabled = false;




                // Busca los datos en la base y carga en los textBox

                if (usuario != null)
                    {
                        Id = usuario.Id;

                        usuario = usuarioNegocio.UsuarioPorID(Id);
                        domicilios = domicilioNegocio.DomicilioUsuario(Id);

                        txtNombres.Text = usuario.Nombre;
                        txtApellidos.Text = usuario.Apellido;
                        txtDNI.Text = usuario.NDocumento;
                        txtCelular.Text = usuario.Contacto;

                        domicilio = domicilios.FirstOrDefault(p => p.IdUsuario == usuario.Id);

                        txtProvincia.Text = domicilio.Provincia;
                        txtCiudad.Text = domicilio.Ciudad;
                        txtCalle.Text = domicilio.Calle;
                        txtAltura.Text = domicilio.Altura.ToString();
                        txtPiso.Text = domicilio.Piso;
                        txtDpto.Text = domicilio.Depto;

                    }


                }




            }


            protected void txtCalle_TextChanged(object sender, EventArgs e)
            {
           
            }


            protected void ButtonGuardar_Click(object sender, EventArgs e)
            {
                Usuario usuario = new Usuario(); 
                Usuario Usuarioaux = new Usuario();
                UsuarioNegocio usuarioNegocioAux = new UsuarioNegocio();
                Domicilio domicilioAux = new Domicilio();
                DomicilioNegocio domicilioNegocioAux = new DomicilioNegocio();
                usuario = Session["Usuario"] as Dominio.Usuario;


                Usuarioaux.Id = usuario.Id;
                Usuarioaux.Contacto = txtCelular.Text;
                domicilioAux.Provincia = txtProvincia.Text;
                domicilioAux.Ciudad = txtCiudad.Text;
                domicilioAux.Calle = txtCalle.Text;
                domicilioAux.Altura =int.Parse(txtAltura.Text);
                domicilioAux.Piso = txtPiso.Text;
                domicilioAux.Depto = txtDpto.Text;

                try
                {
              
                        usuarioNegocioAux.ActualizarDatosUsuario(Usuarioaux, domicilioAux);
                        string script = "alert('Datos actualizados correctamente'); window.location='Inicio.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);
                

                }
                catch (Exception)
                {
                    string script = "alert('Error - No se pudieron actualizar los datos');";
                    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script, true);
                    throw;
                }

            
           
            
             

            
               
            




            }

            protected void ButtonVolver_Click(object sender, EventArgs e)
            {
                Response.Redirect("MiCuenta.aspx");
            }

       
        }
    }