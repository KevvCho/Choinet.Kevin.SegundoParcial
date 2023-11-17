using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Aereo : Heroe, IHeroe
    {

        public int Velocidad { get; set; }
        public bool BooleanoHeroe { get; set; }

        /// <summary>
        /// Constructor con todos los datos pasados por parametro
        /// </summary>
        public Aereo(int velocidadVuelo, bool alas, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.Velocidad = velocidadVuelo;
            this.BooleanoHeroe = alas;
        }
        /// <summary>
        /// Constructor con solo un dato pasado por parametro
        /// </summary>
        public Aereo(int velocidadVuelo, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.Velocidad = velocidadVuelo;
        }
        /// <summary>
        /// Constructor inicializando solo con los parametros base
        /// </summary>
        public Aereo(string nombre, EPoderes poder, int nivelDePoder) : base(nombre, poder, nivelDePoder)
        {
            this.Velocidad = 0;
            this.BooleanoHeroe = false;
        }
        /// <summary>
        /// Calculacion de poder a partir de la velocidad y poder base
        /// </summary>
        /// <returns>Retorna la suma de ambos</returns>
        public override int CalcularPoder()
        {
            int poderTotal;

            poderTotal = this.Velocidad + nivelDePoder;

            return poderTotal;
        }

        /// <summary>
        /// A partir de los dos atributos de este tipo retorna una descripcion personalizada
        /// </summary>
        /// <returns>Retorna un string con la descripcion</returns>
        protected override string ObtenerDescripcion()
        {
            string descripcionAlas = "";

            if (this.BooleanoHeroe == true)
            {
                descripcionAlas = "con alas";
            }
            else
            {
                descripcionAlas = "sin alas";
            }

            return $"¡Soy {this.nombre}, un héroe aéreo {descripcionAlas} y una velocidad de vuelo de {this.Velocidad}!";
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
            bool mismaVelocidadVuelo = Velocidad == otroAereo.Velocidad;
            bool mismasAlas = BooleanoHeroe == otroAereo.BooleanoHeroe;


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
