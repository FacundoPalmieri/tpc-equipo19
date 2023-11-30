using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
