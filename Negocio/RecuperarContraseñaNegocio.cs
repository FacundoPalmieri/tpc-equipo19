using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class RecuperarContraseñaNegocio
    {
        public Usuario ConsultarCredenciales(Usuario usuario)
        {
            Usuario usuarioAux = new Usuario();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT PalabraSeguridad FROM USUARIOS  WHERE Usuario = @Usuario");
                datos.SetearParametro("@Usuario",usuario.User);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    usuarioAux.PalabraSeguridad = (string)datos.lector["PalabraSeguridad"];
                }

                return usuarioAux;
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

        
        public void RestablecerCredenciales(Usuario usuario)
        {
            Usuario usuarioAux = new Usuario();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Update Usuarios Set Contraseña = @Contraseña where Usuario = @Usuario");
                datos.SetearParametro("@Usuario", usuario.User);
                datos.SetearParametro("@Contraseña", usuario.Password);

                datos.EjectuarAccion();



            }
            catch (Exception)
            {

                throw;
            }



        }

    }
}
