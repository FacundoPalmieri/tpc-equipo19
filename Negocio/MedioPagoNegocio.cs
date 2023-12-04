using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MedioPagoNegocio
    {
        public List<MedioPago> listar()
        {
            List<MedioPago> lista = new List<MedioPago>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Nombre From MEDIOS_PAGO");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    MedioPago aux = new MedioPago();
                    aux.Nombre = (string)datos.lector["Nombre"];

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
