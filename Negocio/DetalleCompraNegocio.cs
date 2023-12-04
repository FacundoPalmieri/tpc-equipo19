using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetalleCompraNegocio
    {
        public void AgregarCompra(List<Carrito> listaCarrito, int IdCompra)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearProcedimiento("RegistrarDetalleCompra");

                foreach (var carrito in listaCarrito)
                {
                    Datos.LimpiarParametros(); 

                    Datos.SetearParametro("@IdCompra", IdCompra);
                    Datos.SetearParametro("@IdArticulo", carrito.Articulo.Id); 
                    Datos.SetearParametro("@Cantidad", carrito.Cantidad);
                    Datos.SetearParametro("@Precio", carrito.Total);

                    Datos.EjectuarAccion();
                    Datos.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
