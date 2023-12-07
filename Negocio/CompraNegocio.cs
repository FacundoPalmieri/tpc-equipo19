using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class CompraNegocio
    {
        public List<Compra> listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdUsuario, PrecioVenta, CostoEnvio, PrecioTotal, MetodoEntrega, MedioPago, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto FROM COMPRAS");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)datos.lector["Id"];
                    aux.IdUsuario = (int)datos.lector["IdUsuario"];
                    aux.PrecioVenta = (decimal)datos.lector["PrecioVenta"];
                    aux.CostoEnvio = (decimal)datos.lector["CostoEnvio"];
                    aux.PrecioTotal = (decimal)datos.lector["PrecioTotal"];
                    aux.MetodoEntrega = (string)datos.lector["MetodoEntrega"];
                    aux.MedioPago = (string)datos.lector["MedioPago"];
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

        public Compra CompraPorID(int id)
        {
            Compra compra = new Compra();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, IdUsuario, PrecioVenta, CostoEnvio, PrecioTotal, MetodoEntrega, MedioPago, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto FROM COMPRAS WHERE Id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    compra.Id = (int)datos.lector["Id"];
                    compra.IdUsuario = (int)datos.lector["IdUsuario"];
                    compra.PrecioVenta = (decimal)datos.lector["PrecioVenta"];
                    compra.CostoEnvio = (decimal)datos.lector["CostoEnvio"];
                    compra.PrecioTotal = (decimal)datos.lector["PrecioTotal"];
                    compra.MetodoEntrega = (string)datos.lector["MetodoEntrega"];
                    compra.MedioPago = (string)datos.lector["MedioPago"];
                    compra.FechaCompra = (DateTime)datos.lector["FechaCompra"];
                    compra.Estado = (string)datos.lector["Estado"];
                    compra.Pais = (string)datos.lector["Pais"];
                    compra.Provincia = (string)datos.lector["Provincia"];
                    compra.Ciudad = (string)datos.lector["Ciudad"];
                    compra.Calle = (string)datos.lector["Calle"];
                    compra.Altura = (int)datos.lector["Altura"];
                    compra.Piso = (string)datos.lector["Piso"];
                    compra.Depto = (string)datos.lector["Depto"];
                }

                return compra;
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

        public int AgregarCompra(Compra Nueva)
        {

            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearProcedimiento("RegistrarCompra");
                Datos.SetearParametro("@IdUsuario", Nueva.IdUsuario);
                Datos.SetearParametro("@PrecioVenta", Nueva.PrecioVenta);
                Datos.SetearParametro("@CostoEnvio", Nueva.CostoEnvio);
                Datos.SetearParametro("@PrecioTotal", Nueva.PrecioTotal);
                Datos.SetearParametro(@"MetodoEntrega", Nueva.MetodoEntrega);
                Datos.SetearParametro("@MedioPago", Nueva.MedioPago);
                Datos.SetearParametro("@fechaCompra", Nueva.FechaCompra);
                Datos.SetearParametro("@Estado", Nueva.Estado);
                Datos.SetearParametro("@Pais", Nueva.Pais);
                Datos.SetearParametro("@Provincia", Nueva.Provincia);
                Datos.SetearParametro("@Ciudad", Nueva.Ciudad);
                Datos.SetearParametro("@Calle", Nueva.Calle);
                Datos.SetearParametro("@Altura", Nueva.Altura);
                Datos.SetearParametro("@Piso", Nueva.Piso);
                Datos.SetearParametro("@Depto", Nueva.Depto);
          

                return Datos.EjectuarAccionScalar();

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

        public List<Compra> filtrar(string estado)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = ("SELECT Id, IdUsuario, PrecioVenta, CostoEnvio, PrecioTotal, MetodoEntrega, MedioPago, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto FROM COMPRAS WHERE Estado = @estado");
                datos.SetearConsulta(consulta);
                datos.SetearParametro("@estado", estado);
                
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)datos.lector["Id"];
                    aux.IdUsuario = (int)datos.lector["IdUsuario"];
                    aux.PrecioVenta = (decimal)datos.lector["PrecioVenta"];
                    aux.CostoEnvio = (decimal)datos.lector["CostoEnvio"];
                    aux.PrecioTotal = (decimal)datos.lector["PrecioTotal"];
                    aux.MetodoEntrega = (string)datos.lector["MetodoEntrega"];
                    aux.MedioPago = (string)datos.lector["MedioPago"];
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
        }

        public List<Compra> filtrarPorUsuario(int IdUsuario)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = ("SELECT Id, IdUsuario, PrecioVenta, CostoEnvio, PrecioTotal, MetodoEntrega, MedioPago, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto FROM COMPRAS WHERE IdUsuario = @IdUsuario");
                datos.SetearConsulta(consulta);
                datos.SetearParametro("@IdUsuario", IdUsuario);

                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)datos.lector["Id"];
                    aux.IdUsuario = (int)datos.lector["IdUsuario"];
                    aux.PrecioVenta = (decimal)datos.lector["PrecioVenta"];
                    aux.CostoEnvio = (decimal)datos.lector["CostoEnvio"];
                    aux.PrecioTotal = (decimal)datos.lector["PrecioTotal"];
                    aux.MetodoEntrega = (string)datos.lector["MetodoEntrega"];
                    aux.MedioPago = (string)datos.lector["MedioPago"];
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
        }

        public List<Compra> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = ("SELECT Id, IdUsuario, PrecioVenta, CostoEnvio, PrecioTotal, MetodoEntrega, MedioPago, FechaCompra, Estado, Pais, Provincia, Ciudad, Calle, Altura, Piso, Depto FROM COMPRAS WHERE FechaCompra BETWEEN @FechaInicio AND @FechaFin");
                datos.SetearConsulta(consulta);
                datos.SetearParametro("@FechaInicio", FechaInicio);
                datos.SetearParametro("@FechaFin", FechaFin);

                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Compra aux = new Compra();
                    aux.Id = (int)datos.lector["Id"];
                    aux.IdUsuario = (int)datos.lector["IdUsuario"];
                    aux.PrecioVenta = (decimal)datos.lector["PrecioVenta"];
                    aux.CostoEnvio = (decimal)datos.lector["CostoEnvio"];
                    aux.PrecioTotal = (decimal)datos.lector["PrecioTotal"];
                    aux.MetodoEntrega = (string)datos.lector["MetodoEntrega"];
                    aux.MedioPago = (string)datos.lector["MedioPago"];
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
        }

    }
}
