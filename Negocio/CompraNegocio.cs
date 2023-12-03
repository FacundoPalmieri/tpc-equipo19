using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class CompraNegocio
    {
        public List<Compra> listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdUsuario, PrecioTotal, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto FROM COMPRAS");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)datos.lector["Id"];
                    aux.IdUsuario = (int)datos.lector["IdUsuario"];
                    aux.PrecioTotal = (decimal)datos.lector["PrecioTotal"];
                    aux.FechaCompra = (DateTime)datos.lector["FechaCompra"];
                    aux.Estado = (string)datos.lector["Estado"];
                    aux.Pais = (string)datos.lector["Pais"];
                    aux.Provincia = (string)datos.lector["Provincia"];
                    aux.Ciudad = (string)datos.lector["Ciudad"];
                    aux.Calle = (string)datos.lector["Calle"];
                    aux.Altura = (int)datos.lector["Altura"];
                    aux.Piso = (string)datos.lector["Piso"];
                    aux.Depto = (string)datos.lector["Depto"];

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

        public void Agregar(Compra Nueva)
        {

            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("Insert into COMPRAS(IdUsuario, PrecioTotal, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto) values('" + Nueva.IdUsuario + "','" + Nueva.PrecioTotal + "','" + Nueva.FechaCompra + "','" + Nueva.Estado + "','" + Nueva.Pais + "','" + Nueva.Provincia + "','" + Nueva.Ciudad + "','" + Nueva.Calle + "','" + Nueva.Altura + "','" + Nueva.Piso +"','" + Nueva.Piso + "','" + Nueva.Depto + "')");
                Datos.SetearParametro("@IdUsuario", Nueva.IdUsuario);
                Datos.SetearParametro("@PrecioTotal", Nueva.PrecioTotal);
                Datos.SetearParametro("@fechaCompra", Nueva.FechaCompra);
                Datos.SetearParametro("@Estado", Nueva.Estado);
                Datos.SetearParametro("@Pais", Nueva.Pais);
                Datos.SetearParametro("@Provincia", Nueva.Provincia);
                Datos.SetearParametro("@Ciudad", Nueva.Ciudad);
                Datos.SetearParametro("@Calle", Nueva.Calle);
                Datos.SetearParametro("@Altura", Nueva.Altura);
                Datos.SetearParametro("@Piso", Nueva.Piso);
                Datos.SetearParametro("@Depto", Nueva.Depto);
                Datos.EjectuarAccion();

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

        public void Modificar(Compra compra)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("update COMPRAS set Estado = @Estado where Id = @Id");
                Datos.SetearParametro("@Id", compra.Id);
                Datos.SetearParametro("@Estado", compra.Estado);
                Datos.EjectuarAccion();
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
