﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Data;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Lector;

        public SqlDataReader lector
        {
            get { return Lector; }
        }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("server=.\\SQLEXPRESS; database=KFMarket; integrated security=true");
            Comando = new SqlCommand();
        }

        public void SetearConsulta(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }

        public void EjecutarConsulta()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EjectuarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

        }

     


        public int EjectuarAccionScalar()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                return int.Parse(Comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void SetearParametro(string Nombre, Object Valor)
        {
            Comando.Parameters.AddWithValue(Nombre, Valor);
        }


        public void SetearProcedimiento(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;   

        }

        public void LimpiarParametros()
        {
            if (Comando != null && Comando.Parameters.Count > 0)
            {
                Comando.Parameters.Clear();
            }
        }

        public void CerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
            }
            Conexion.Close();
        }
    }
}
