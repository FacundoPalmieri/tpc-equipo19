using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoCompraNegocio
    {
        public List<EstadoCompra> listar()
        {
            List<EstadoCompra> lista = new List<EstadoCompra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id, Estado From ESTADOCOMPRA");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    EstadoCompra aux = new EstadoCompra();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Estado = (string)datos.lector["Estado"];

                    lista.Add(aux);
                }

                return lista;
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
