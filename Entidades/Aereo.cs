using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aereo : Heroe
    {
        private int velocidadVuelo;
        private bool alas;

        public int VelocidadVuelo { get => velocidadVuelo; set => velocidadVuelo = value; }
        public bool Alas { get => alas; set => alas = value; }
        /// <summary>
        /// Constructor con todos los datos pasados por parametro
        /// </summary>
        public Aereo(int velocidadVuelo, bool alas, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.velocidadVuelo = velocidadVuelo;
            this.alas = alas;
        }
        /// <summary>
        /// Constructor con solo un dato pasado por parametro
        /// </summary>
        public Aereo(int velocidadVuelo, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.velocidadVuelo = velocidadVuelo;
        }
        /// <summary>
        /// Constructor inicializando solo con los parametros base
        /// </summary>
        public Aereo(string nombre, EPoderes poder, int nivelDePoder) : base(nombre, poder, nivelDePoder)
        {
            this.velocidadVuelo = 0;
            this.alas = false;
        }
        /// <summary>
        /// Calculacion de poder a partir de la velocidad y poder base
        /// </summary>
        /// <returns>Retorna la suma de ambos</returns>
        public override int CalcularPoder()
        {
            int poderTotal;

            poderTotal = this.velocidadVuelo + nivelDePoder;

            return poderTotal;
        }

        /// <summary>
        /// A partir de los dos atributos de este tipo retorna una descripcion personalizada
        /// </summary>
        /// <returns>Retorna un string con la descripcion</returns>
        protected override string ObtenerDescripcion()
        {
            string descripcionAlas = "";

            if (this.alas == true)
            {
                descripcionAlas = "con alas";
            }
            else
            {
                descripcionAlas = "sin alas";
            }

            return $"¡Soy {this.nombre}, un héroe aéreo {descripcionAlas} y una velocidad de vuelo de {this.velocidadVuelo}!";
        }


        public override string ToString()
        {
            return ObtenerDescripcion();
        }

        /// <summary>
        /// Combina el hashcode de los 3 atributos para generar uno nuevo
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(nombre, poder, nivelDePoder);
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

            Aereo otroAereo = (Aereo)obj;

            bool mismoNombre = nombre == otroAereo.nombre;
            bool mismoPoder = poder == otroAereo.poder;
            bool mismoNivelDePoder = nivelDePoder == otroAereo.nivelDePoder;
            bool mismaVelocidadVuelo = velocidadVuelo == otroAereo.velocidadVuelo;
            bool mismasAlas = alas == otroAereo.alas;


            if (mismoNombre && mismoPoder && mismoNivelDePoder && mismaVelocidadVuelo && mismasAlas)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
