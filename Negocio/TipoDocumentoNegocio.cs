using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoDocumentoNegocio
    {
        public List<TipoDocumento> listarTiposDocumentos()
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Nombre From TiposDocumentos");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    TipoDocumento aux = new TipoDocumento();
                    aux.Nombre = (string)(datos.lector["Nombre"]);
                    lista.Add(aux);
                }
                return lista;

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
    }
}
