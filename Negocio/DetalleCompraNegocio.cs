using System;
using System.Collections;
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

        public List<DetalleCompra> Listar()
        {
            List<DetalleCompra> Lista = new List<DetalleCompra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("SELECT IdCompra, IdArticulo, Cantidad, Precio FROM DETALLESCOMPRAS");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    DetalleCompra Aux = new DetalleCompra();
                    Aux.IdCompra = (int)datos.lector["IdCompra"];
                    Aux.IdArticulo = (int)datos.lector["IdArticulo"];
                    Aux.Cantidad = (int)datos.lector["Cantidad"];
                    Aux.Precio = (int)datos.lector["Precio"];

                    Lista.Add(Aux);
                }
                return Lista;
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

        public List<DetalleCompra> ListarPorID(int id)
        {
            List<DetalleCompra> Lista = new List<DetalleCompra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT IdCompra, IdArticulo, Cantidad, Precio FROM DETALLESCOMPRAS WHERE IdCompra = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    DetalleCompra Aux = new DetalleCompra();

                    Aux.IdCompra = (int)datos.lector["IdCompra"];
                    Aux.IdArticulo = (int)datos.lector["IdArticulo"];
                    Aux.Cantidad = (int)datos.lector["Cantidad"];
                    Aux.Precio = (decimal)datos.lector["Precio"];
                    Lista.Add(Aux);
                }

                return Lista;
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
