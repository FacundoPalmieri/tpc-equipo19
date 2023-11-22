using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id, Descripcion From Categorias");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Categoria aux = new Categoria();
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

        public List<Categoria> ListarPorID(int id)
        {
            List<Categoria> Lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion from CATEGORIAS");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Categoria Aux = new Categoria();

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

        public void Agregar(Categoria Nuevo)
        {

            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("Insert into CATEGORIAS(Descripcion) values('" + Nuevo.Descripcion + "')");
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

        public void Modificar(Categoria categoria)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("update CATEGORIAS set Descripcion = @Descripcion where Id = @Id");
                Datos.SetearParametro("@Id", categoria.Id);
                Datos.SetearParametro("@Descripcion", categoria.Descripcion);
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
                datos.SetearConsulta("delete from CATEGORIAS where Id = @id");
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
