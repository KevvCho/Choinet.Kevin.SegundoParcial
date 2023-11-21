using System.Text.Json.Serialization;

namespace Entidades
{
    public abstract class Heroe
    {

        protected string nombre;
        protected EPoderes poder;
        protected int nivelDePoder;

        public string Nombre { get => nombre; set => nombre = value; }
        public EPoderes Poder { get => poder; set => poder = value; }
        public int NivelDePoder { get => nivelDePoder; set => nivelDePoder = value; }

        /// <summary>
        /// Constructor con todos los datos posibles llamando a los dos anteriores
        /// </summary>
        public Heroe(string nombre, EPoderes poder, int nivelDePoder) : this (nombre, poder)
        {
            this.nivelDePoder = nivelDePoder;
        }
        /// <summary>
        /// Constructor solo tomando como parametro nombre y tipo de poder
        /// </summary>
        public Heroe(string nombre, EPoderes poder) : this()
        {
            this.nombre = nombre;
            this.poder = poder;
        }
        /// <summary>
        /// Constructor para generar un heroe por default
        /// </summary>
        public Heroe()
        {
            this.nombre = "Sin nombre";
            this.poder = EPoderes.Telepatia;
            this.nivelDePoder = 0;
        }

        /// <summary>
        /// Metodo para sumar velocidades y nivel base en cada clase
        /// </summary>
        /// <returns>Numero de poder total ya sumado</returns>
        public abstract int CalcularPoder();

        
        protected virtual string ObtenerDescripcion()
        {
            return $"El nombre del heroe es {this.nombre}, su super poder es {this.poder} y tiene un nivel de poder de {this.nivelDePoder}";
        }


        public override string ToString()
        {
            return ObtenerDescripcion();
        }

        /// <summary>
        /// Combina el hashcode de los 3 atributos para generar uno nuevo
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.nombre, this.poder, this.nivelDePoder);
        }

        /// <summary>
        /// Comparacion de igualdad de datos de heroe y en caso de un objeto de tipo null
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Heroe other = (Heroe)obj;
            bool nombresIguales = nombre == other.nombre;
            bool poderesIguales = poder == other.poder;

            if (nombresIguales && poderesIguales)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Verificacion de dato null y llamado a Equals
        /// </summary>
        /// <returns></returns>
        public static bool operator ==(Heroe heroe1, Heroe heroe2)
        {
            if (ReferenceEquals(heroe1, heroe2))
            {
                return true;
            }

            if (ReferenceEquals(heroe1, null) || ReferenceEquals(heroe2, null))
            {
                return false;
            }

            return heroe1.Equals(heroe2);
        }

        public static bool operator !=(Heroe heroe1, Heroe heroe2)
        {
            return !(heroe1 == heroe2);
        }
        /// <summary>
        /// Casteo implicito para obtener el nombre del heroe a partir de un string
        /// </summary>
        public static implicit operator string(Heroe heroe)
        {
            return heroe?.nombre;
        }
    }
}