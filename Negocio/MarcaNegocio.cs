using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id, Descripcion From Marcas");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.lector["Id"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];

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

        public List<Marca> ListarPorID(int id)
        {
            List<Marca> Lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion from MARCAS");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Marca Aux = new Marca();

                    Aux.Id = (int)datos.lector["Id"];
                    Aux.Descripcion = (string)datos.lector["Descripcion"];

                    bool EstaEnLista = Lista.Any(item => Aux.Id == item.Id);

                    if (!EstaEnLista)
                    {
                        Lista.Add(Aux);
                    }
                }

                // Filtrar la lista por el Id que se pasa como parámetro
                Lista = Lista.Where(item => item.Id == id).ToList();

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

        public void Agregar(Marca Nuevo)
        {

            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("Insert into MARCAS(Descripcion) values('" + Nuevo.Descripcion + "')");
                Datos.SetearParametro("@Id", Nuevo.Id);
                Datos.SetearParametro("@Descripcion", Nuevo.Descripcion);
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

        public void Modificar(Marca marca)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("update MARCAS set Descripcion = @Descripcion where Id = @Id");
                Datos.SetearParametro("@Id", marca.Id);
                Datos.SetearParametro("@Descripcion", marca.Descripcion);
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

        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from MARCAS where Id = @id");
                datos.SetearParametro("@id", id);
                datos.EjectuarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

