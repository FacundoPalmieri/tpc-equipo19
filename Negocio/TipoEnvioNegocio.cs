using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoEnvioNegocio
    {
        public decimal CostoEnvio(int Id)
        {
            decimal CostoEnvio = new decimal();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT TP.Costo FROM TiposEntrega TP Where TP.ID = @Id");
                datos.SetearParametro("@id", Id);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
              
                   CostoEnvio= (decimal)datos.lector["Costo"];

                }

                return CostoEnvio;
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
