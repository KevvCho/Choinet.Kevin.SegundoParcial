using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Entidades
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private static string cadena_conexion;

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.conexionProperties;
        }

        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }

        public bool PruebaConexion()
        {
            bool retorno = false;
            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }

            }
            return retorno;
        }

        
    }
}
