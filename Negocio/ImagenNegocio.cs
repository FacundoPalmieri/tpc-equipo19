using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("Select IdArticulo, ImagenUrl From Imagenes");
                Datos.EjecutarConsulta();

                while (Datos.lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdCodigoArticulo = (int)Datos.lector["IdArticulo"];
                    string ImagenUrl = (string)Datos.lector["ImagenUrl"];

                    
                    if (aux.ListaDeImagenes == null)
                    {
                        aux.ListaDeImagenes = new List<string>();
                    }

                    aux.ListaDeImagenes.Add(ImagenUrl);

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
                Datos.CerrarConexion();
            }


        }

        public void Agregar(Articulo Nuevo, int id)
        {
            Articulo articulo = new Articulo();
            AccesoDatos Datos = new AccesoDatos();

            try
            {
                Datos.SetearConsulta("Insert into IMAGENES(IdArticulo, ImagenUrl) values(@IdCodigoArticulo, @ImagenUrl)");
                Datos.SetearParametro("@IdCodigoArticulo", id);
                foreach (string imagenUrl in articulo.imagen.ListaDeImagenes )
                {
                    Datos.SetearParametro("@ImagenUrl", imagenUrl);
                }
                Datos.EjectuarAccion();
                Datos.CerrarConexion();

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

        public void Modificar(Articulo articulo, int articuloId)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {

                Datos.SetearConsulta("update IMAGENES set ImagenUrl = @ImagenUrl where IdArticulo = '" + articuloId + "'");
                foreach (string imagenUrl in articulo.imagen.ListaDeImagenes)
                {
                  Datos.SetearParametro("@ImagenUrl", imagenUrl);
            
                }
             


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



        public List<Articulo> ProximaImagen(Articulo articulo)
        {
            AccesoDatos Datos = new AccesoDatos();

            try
            {

                Articulo aux1 = new Articulo();
                List<Articulo> articulosAux = new List<Articulo>();
                Datos.SetearConsulta("SELECT a.Codigo, i.ImagenUrl  From ARTICULOS a inner join IMAGENES i on a.Id = i.IdArticulo order by a.Codigo");
                Datos.EjecutarConsulta();
                while (Datos.lector.Read())
                {
                    aux1.CodigoArticulo = (string)Datos.lector["Codigo"];

                    if (aux1.CodigoArticulo == articulo.CodigoArticulo)
                    {
                        Articulo aux = new Articulo();
                        aux.CodigoArticulo = articulo.CodigoArticulo;
                        aux.imagen = new Imagen();
                        string imagenUrl = (string)Datos.lector["ImagenUrl"];
                        aux.imagen.ListaDeImagenes.Add(imagenUrl);
                        articulosAux.Add(aux);


                    }

                }
                return articulosAux;
                throw new Exception("No se encontró ninguna imagen para el artículo especificado");





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
