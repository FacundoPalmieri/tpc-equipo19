using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DomicilioNegocio
    {

        public List<Pais> listarPaises()
        {
            List<Pais> lista = new List<Pais>();
          
            AccesoDatos datos = new AccesoDatos();
     
            try
            {
                datos.SetearConsulta("Select Nombre From Paises");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Pais aux = new Pais();
                    //Domicilio.Id = (int)datos.lector["Id"];
                    aux.Nombre = (string)(datos.lector["Nombre"]);
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }


        }

        public List<Provincia> listarProvincias()
        {
            List<Provincia> lista = new List<Provincia>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id, Nombre From Provincias");
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Provincia aux = new Provincia();
                    aux.Id = (int)(datos.lector["Id"]);
                    aux.Nombre = (string)(datos.lector["Nombre"]);
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }


        }

        public List<Ciudad> listarCiudades(int Idprovincia)
        {
            List<Ciudad> lista = new List<Ciudad>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Nombre From Ciudades Where idProvincia = @IdProvincia");
                datos.SetearParametro("@IdProvincia", Idprovincia);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Ciudad aux = new Ciudad();
                    //Domicilio.Id = (int)datos.lector["Id"];
                    aux.Nombre = (string)(datos.lector["Nombre"]);
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                datos.CerrarConexion();
            }


        }

        public int RegistrarDomicilio(Domicilio Nuevo, int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("RegistrarDomicilio");
                datos.SetearParametro("@IdUsuario", IdUsuario);
                datos.SetearParametro("@Pais", Nuevo.Pais);
                datos.SetearParametro("@Provincia", Nuevo.Provincia);
                datos.SetearParametro("@Ciudad", Nuevo.Ciudad);
                datos.SetearParametro("@Calle", Nuevo.Calle);
                datos.SetearParametro("@Altura", Nuevo.Altura);
                datos.SetearParametro("@Piso", Nuevo.Piso);
                datos.SetearParametro("@Depto", Nuevo.Depto);

                return datos.EjectuarAccionScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


    }
}
