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
        private SqlCommand comando;
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

        public string AgregarDato(ColeccionHeroes<Heroe> coleccion)
        {
            bool asd = false;
            string retorno = "";
            try
            {
                this.conexion.Open(); 

                foreach (Heroe heroe in coleccion)
                {
                    this.comando = new SqlCommand();
                    this.comando.Parameters.AddWithValue("@nombre", heroe.Nombre);
                    this.comando.Parameters.AddWithValue("@poder", heroe.Poder.ToString());
                    this.comando.Parameters.AddWithValue("@nivelPoder", heroe.NivelDePoder);

                    if (heroe is Terrestre terrestre)
                    {
                        this.comando.Parameters.AddWithValue("@tipo", "Terrestre");
                        this.comando.Parameters.AddWithValue("@velocidad", terrestre.Velocidad);
                        this.comando.Parameters.AddWithValue("@habilidadBool", terrestre.BooleanoHeroe);
                    }
                    else if (heroe is Aereo aereo)
                    {
                        this.comando.Parameters.AddWithValue("@tipo", "Aereo");
                        this.comando.Parameters.AddWithValue("@velocidad", aereo.Velocidad);
                        this.comando.Parameters.AddWithValue("@habilidadBool", aereo.BooleanoHeroe);
                    }
                    else if (heroe is Acuatico acuatico)
                    {
                        this.comando.Parameters.AddWithValue("@tipo", "Acuatico");
                        this.comando.Parameters.AddWithValue("@velocidad", acuatico.Velocidad);
                        this.comando.Parameters.AddWithValue("@habilidadBool", acuatico.BooleanoHeroe);
                    }

                    this.comando.CommandType = System.Data.CommandType.Text;
                    this.comando.CommandText = "insert into tabla_heroes (tipo, velocidad, habilidadBool, nombre, poder, nivelPoder) values (@tipo, @velocidad, @habilidadBool, @nombre, @poder, @nivelPoder)";
                    //this.comando.CommandText = "delete from tabla_heroes";
                    this.comando.Connection = this.conexion;

                    int filasAfectadas = this.comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        asd = true;
                    }
                }

                this.conexion.Close();
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }
    }
}
