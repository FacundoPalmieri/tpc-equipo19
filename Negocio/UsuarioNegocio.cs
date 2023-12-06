using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select Id, Usuario, contraseña, tipousuario From USUARIOS Where usuario = @user And contraseña = @pass");
                datos.SetearParametro("@user", usuario.User);
                datos.SetearParametro("@pass", usuario.Password);

                datos.EjecutarConsulta();
                while(datos.lector.Read())
                {
                    usuario.Id = (int)datos.lector["Id"];
                    usuario.TipoUsuario = (int)(datos.lector["TipoUsuario"]) == 2 ? TipoUsuario.Administrador : TipoUsuario.Cliente;
                    return true;
                }
                return false;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public int RegistrarUsuario(Usuario Nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("RegistrarUsuario");
                datos.SetearParametro("@Nombre", Nuevo.Nombre);
                datos.SetearParametro("@Apellido", Nuevo.Apellido);
                datos.SetearParametro("@TipoDocumento", Nuevo.TipoDocumento);
                datos.SetearParametro("@NDocumento", Nuevo.NDocumento);
                datos.SetearParametro("@Contacto", Nuevo.Contacto);
                datos.SetearParametro("@Usuario", Nuevo.User);
                datos.SetearParametro("@Contraseña", Nuevo.Password);
                datos.SetearParametro("@PalabraSeguridad", Nuevo.PalabraSeguridad);




                return datos.EjectuarAccionScalar();
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void ActualizarDatosUsuario(Usuario usuario, Domicilio domicilio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("ActualizarDatosUsuario");
                datos.SetearParametro("@IdUsuario", usuario.Id);
                datos.SetearParametro("@Contacto", usuario.Contacto);
                datos.SetearParametro("@Provincia",domicilio.Provincia);
                datos.SetearParametro("@Ciudad", domicilio.Ciudad);
                datos.SetearParametro("@Calle", domicilio.Calle);
                datos.SetearParametro("@Altura", domicilio.Altura);
                datos.SetearParametro("@Piso", domicilio.Piso);
                datos.SetearParametro("@Depto", domicilio.Depto);


                 datos.EjectuarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public Usuario UsuarioPorID(int id)
        {
            Usuario usuario = new Usuario();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, u.Nombre, u.Apellido, u.Contacto, u.Ndocumento, u.TipoUsuario, u.Usuario FROM USUARIOS u WHERE Id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    usuario.Id = (int)datos.lector["Id"];
                    usuario.Nombre = (string)datos.lector["Nombre"];
                    usuario.Apellido = (string)datos.lector["Apellido"];
                    usuario.Contacto = (string)datos.lector["Contacto"];
                    usuario.NDocumento = (string)datos.lector["Ndocumento"];
                    usuario.User = (string)datos.lector["Usuario"];
                    int tipoUsuarioValor = (int)datos.lector["TipoUsuario"];
                    usuario.TipoUsuario = (TipoUsuario)tipoUsuarioValor;

                }

                return usuario;
            }


            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.CerrarConexion();
            }

           

        }
    }

}
