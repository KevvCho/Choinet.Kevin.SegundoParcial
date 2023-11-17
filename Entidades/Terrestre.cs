using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Terrestre : Heroe
    {
        public int Velocidad { get; set; }
        public bool BooleanoHeroe { get; set; }

        /// <summary>
        /// Constructor con todos los datos pasados por parametro
        /// </summary>
        public Terrestre(int velocidad, bool superFuerza, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.BooleanoHeroe = superFuerza;
            this.Velocidad = velocidad;
        }
        /// <summary>
        /// Constructor con solo un dato pasado por parametro
        /// </summary>
        public Terrestre(bool superFuerza, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.BooleanoHeroe = superFuerza;
        }
        /// <summary>
        /// Constructor inicializando solo con los parametros base
        /// </summary>
        public Terrestre(string nombre, EPoderes poder, int nivelDePoder) : base(nombre, poder, nivelDePoder)
        {
            this.BooleanoHeroe = false;
            this.Velocidad = 0;
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
            string descripcionVelocidad = $"con un nivel de velocidad de {Velocidad}";

            string descripcionFuerza = "";

            if (this.BooleanoHeroe)
            {
                descripcionFuerza = $"con super fuerza";
            }
            else
            {
                descripcionFuerza = "sin super fuerza";
            }

            return $"¡Soy {this.nombre}, un héroe terrestre {descripcionFuerza} y {descripcionVelocidad}!";
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

            Terrestre otroTerrestre = (Terrestre)obj;

            bool mismoNombre = nombre == otroTerrestre.nombre;
            bool mismoPoder = poder == otroTerrestre.poder;
            bool mismoNivelDePoder = nivelDePoder == otroTerrestre.nivelDePoder;
            bool mismaSuperFuerza = BooleanoHeroe == otroTerrestre.BooleanoHeroe;
            bool mismaVelocidad = Velocidad == otroTerrestre.Velocidad;

            
            if (mismoNombre && mismoPoder && mismoNivelDePoder && mismaSuperFuerza && mismaVelocidad)
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
