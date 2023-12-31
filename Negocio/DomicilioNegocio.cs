﻿using Dominio;
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


        public int ConsultarProvincias(int IdUsuario)
        {
            int aux = new int ();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select P.Id as Id from Domicilios D left join Provincias P ON P.Nombre = D.Provincia WHERE IdUsuario = @IdUsuario");
               
                datos.SetearParametro("@IdUsuario", IdUsuario);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    aux= (int)(datos.lector["Id"]);
                 
                    
                }
                return aux;

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

        public List<Domicilio> DomicilioUsuario(int id_usuario)
        {
            List<Domicilio> Lista = new List<Domicilio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT IdUsuario,Pais, Provincia, Ciudad, Calle, Altura, CASE WHEN piso!=0 Then Piso ELSE '-' end As Piso, CASE WHEN Depto!= '-' Then Depto ELSE '-' end as Depto FROM DOMICILIOS Where IdUsuario = @IdUsuario");
                datos.SetearParametro("@IdUsuario", id_usuario);
                datos.EjecutarConsulta();

                while (datos.lector.Read())
                {
                    Domicilio Aux = new Domicilio();

                    Aux.IdUsuario = (int)datos.lector["IdUsuario"];
                    Aux.Pais = (string)datos.lector["Pais"];
                    Aux.Provincia= (string)datos.lector["provincia"];
                    Aux.Ciudad = (string)datos.lector["Ciudad"];
                    Aux.Calle = (string)datos.lector["Calle"];
                    Aux.Altura = (int)datos.lector["Altura"];
                    Aux.Piso = (string)datos.lector["Piso"];
                    Aux.Depto = (string)datos.lector["Depto"];

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

        public void ActualizarDomicilio(Compra domicilio, int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearProcedimiento("ActualizarDomicilio");
                datos.SetearParametro("@IdUsuario", IdUsuario);
                datos.SetearParametro("@Pais", domicilio.Pais);
                datos.SetearParametro("@Provincia", domicilio.Provincia);
                datos.SetearParametro("@Ciudad", domicilio.Ciudad);
                datos.SetearParametro("@Calle", domicilio.Calle);
                datos.SetearParametro("@Altura", domicilio.Altura);
                datos.SetearParametro("@Piso", domicilio.Piso);
                datos.SetearParametro("@Depto", domicilio.Depto);

                datos.EjectuarAccion();

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
