using System;
using System.Collections.Generic;
using System.Data;
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
        public event EventHandler OperacionCompletada;
        public event EventHandler OperacionFallo;

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.conexionProperties;
        }

        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }
        /// <summary>
        /// Realiza una comprobacion de la conexion a la base de datos
        /// </summary>
        /// <returns>Retorna el resultado de la misma</returns>
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
        /// <summary>
        /// Se encarga de limpiar todos los datos en la tabla de SQL
        /// </summary>
        /// <returns>Retorna la verificacion de la operacion</returns>
        public string BorrarDatosTabla()
        {
            string retorno = "";
            try
            {
                this.conexion.Open();

                this.comando = new SqlCommand("DELETE FROM tabla_heroes", this.conexion);
                this.comando.ExecuteNonQuery();

                retorno = "Datos borrados correctamente.";

                this.conexion.Close();
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Agrega todos los heroes dentro de una coleccion hacia la tabla de datos SQL
        /// </summary>
        /// <param name="coleccion">Coleccion de heroes para agregar</param>
        public void AgregarColeccion(ColeccionHeroes<Heroe> coleccion)
        {
            bool retorno = false;
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
                    this.comando.CommandText = "INSERT INTO tabla_heroes (tipo, velocidad, habilidadBool, nombre, poder, nivelPoder) VALUES (@tipo, @velocidad, @habilidadBool, @nombre, @poder, @nivelPoder)";
                    this.comando.Connection = this.conexion;

                    int filasAfectadas = this.comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    { 
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                        break;
                    }
                }
                
                this.conexion.Close();
            }
            catch (Exception e)
            {
                OnOperacionFallo();
            }

            if (retorno)
            {
                OnOperacionCompletada();
            }
            else
            {
                OnOperacionFallo();
            }

        }

        protected virtual void OnOperacionCompletada()
        {
            OperacionCompletada?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnOperacionFallo()
        {
            OperacionFallo?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Agrega solo un heroe junto a sus datos a la tabla
        /// </summary>
        /// <param name="heroe">Heroe a agregar</param>
        /// <returns>Retorna una verificacion de la operacion</returns>
        public bool AgregarHeroeBD(Heroe heroe)
        {
            bool retorno = false;
            try
            {
                this.conexion.Open();

                this.comando = new SqlCommand("SELECT COUNT(*) FROM tabla_heroes WHERE CAST(nombre AS nvarchar(MAX)) = @nombre AND CAST(poder AS nvarchar(MAX)) = @poder AND nivelPoder = @nivelPoder", this.conexion);
                this.comando.Parameters.AddWithValue("@nombre", heroe.Nombre);
                this.comando.Parameters.AddWithValue("@poder", heroe.Poder.ToString());
                this.comando.Parameters.AddWithValue("@nivelPoder", heroe.NivelDePoder);

                int registrosExistentes = Convert.ToInt32(this.comando.ExecuteScalar());

                if (registrosExistentes == 0)
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
                    this.comando.CommandText = "INSERT INTO tabla_heroes (tipo, velocidad, habilidadBool, nombre, poder, nivelPoder) VALUES (@tipo, @velocidad, @habilidadBool, @nombre, @poder, @nivelPoder)";
                    this.comando.Connection = this.conexion;

                    int filasAfectadas = this.comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
                else
                {
                    retorno = false;
                }

                this.conexion.Close();
            }
            catch (Exception e)
            {
                retorno = false;
            }

            if (retorno)
            {
                OnOperacionCompletada();
            }
            else
            {
                OnOperacionFallo();
            }

            return retorno;
        }
        /// <summary>
        /// Lector de la tabla en la base de datos SQL
        /// </summary>
        /// <returns>Retorna la verificacion de la operacion</returns>
        public ColeccionHeroes<Heroe> LeerDatosBD()
        {
            ColeccionHeroes<Heroe> coleccion = new ColeccionHeroes<Heroe>();

            try
            {
                this.conexion.Open();

                SqlCommand comando = new SqlCommand("SELECT tipo, velocidad, CAST(habilidadBool AS bit) AS habilidad, nombre, poder, nivelPoder FROM tabla_heroes", this.conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string tipo = reader.GetString(0);
                    int velocidad = reader.GetInt32(1);
                    bool habilidadBool = reader.GetBoolean(2);
                    string nombre = reader.GetString(3);
                    string poder = reader.GetString(4);
                    int nivelPoder = reader.GetInt32(5);

                    EPoderes poderEnum = (EPoderes)Enum.Parse(typeof(EPoderes), poder, ignoreCase: true);

                    Heroe nuevoHeroe = null;

                    if (tipo == "Acuatico")
                    {
                        nuevoHeroe = new Acuatico(velocidad, habilidadBool, nombre, poderEnum, nivelPoder);
                    }
                    else if (tipo == "Aereo")
                    {
                        nuevoHeroe = new Aereo(velocidad, habilidadBool, nombre, poderEnum, nivelPoder);
                    }
                    else if (tipo == "Terrestre")
                    {
                        nuevoHeroe = new Terrestre(velocidad, habilidadBool, nombre, poderEnum, nivelPoder);
                    }

                    if (nuevoHeroe != null)
                    {
                        coleccion.AgregarHeroe(nuevoHeroe);
                    }

                }

                reader.Close();
                this.conexion.Close();
                return coleccion;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer los datos: " + e.ToString());
                return coleccion;
            }
        }
        /// <summary>
        /// Borra solo un heroe en la base de datos a partir de su nombre, poder y nivel de poder
        /// </summary>
        /// <returns>Retorna una verificacion de la eliminacion</returns>
        public bool EliminarHeroeBD(string nombre, string poder, int nivelPoder)
        {
            bool retorno = false;
            try
            {
                this.conexion.Open();

                this.comando = new SqlCommand("DELETE FROM tabla_heroes WHERE CAST(nombre AS nvarchar(MAX)) = @nombre", this.conexion);
                this.comando.Parameters.AddWithValue("@nombre", nombre);
                this.comando.Parameters.AddWithValue("@poder", poder);
                this.comando.Parameters.AddWithValue("@nivelPoder", nivelPoder);

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }

                this.conexion.Close();
            }
            catch (Exception e)
            {
                retorno = false;
            }

            if (retorno)
            {
                OnOperacionCompletada();
            }
            else
            {
                OnOperacionFallo();
            }

            return retorno;
        }
        /// <summary>
        /// Toma los datos de un heroe y luego de verificar su existencia los edita por nuevos datos ingresados.
        /// </summary>
        /// <returns>Retorna una verificacion del proceso.</returns>
        public bool EditarHeroeBD(string nombreOriginal, string nuevoNombre, string poder, int nivelPoder, int velocidad)
        {
            bool retorno = false;
            try
            {
                this.conexion.Open();

                this.comando = new SqlCommand("UPDATE tabla_heroes SET nombre = @nuevoNombre, poder = @poder, nivelPoder = @nivelPoder, velocidad = @velocidad WHERE CAST(nombre AS nvarchar(MAX)) = @nombreOriginal", this.conexion);
                this.comando.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                this.comando.Parameters.AddWithValue("@poder", poder);
                this.comando.Parameters.AddWithValue("@nivelPoder", nivelPoder);
                this.comando.Parameters.AddWithValue("@velocidad", velocidad);
                this.comando.Parameters.AddWithValue("@nombreOriginal", nombreOriginal);

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }

                this.conexion.Close();
            }
            catch (Exception e)
            {
                retorno = false;
            }

            if (retorno)
            {
                OnOperacionCompletada();
            }
            else
            {
                OnOperacionFallo();
            }

            return retorno;
        }
    }
}
