using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Acuatico : Heroe, IHeroe
    {

        public int Velocidad { get; set; }
        public bool BooleanoHeroe { get; set; }

        /// <summary>
        /// Constructor con todos los datos pasados por parametro
        /// </summary>
        public Acuatico(int velocidadNatacion, bool comunicacionMarina, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.BooleanoHeroe = comunicacionMarina;
            this.Velocidad = velocidadNatacion;
        }
        /// <summary>
        /// Constructor con solo un dato pasado por parametro
        /// </summary>
        public Acuatico(int velocidadNatacion, string nombre, EPoderes poder, int nivelDePoder) : this(nombre, poder, nivelDePoder)
        {
            this.Velocidad = velocidadNatacion;
        }
        /// <summary>
        /// Constructor inicializando solo con los parametros base
        /// </summary>
        public Acuatico(string nombre, EPoderes poder, int nivelDePoder) : base(nombre, poder, nivelDePoder)
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
            string descripcionComunicacion = "";

            if (this.BooleanoHeroe == true)
            {
                descripcionComunicacion = "con habilidad de comunicación marina";
            }
            else
            {
                descripcionComunicacion = "sin habilidad de comunicación marina";
            }

            return $"¡Soy {nombre}, un héroe acuático con una velocidad de natación de {this.Velocidad} y {descripcionComunicacion}!";
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

            Acuatico otroAcuatico = (Acuatico)obj;

            bool mismoNombre = nombre == otroAcuatico.nombre;
            bool mismoPoder = poder == otroAcuatico.poder;
            bool mismoNivelDePoder = nivelDePoder == otroAcuatico.nivelDePoder;
            bool mismaVelocidadNatacion = Velocidad == otroAcuatico.Velocidad;
            bool mismaComunicacionMarina = BooleanoHeroe == otroAcuatico.BooleanoHeroe;

            
            if (mismoNombre && mismoPoder && mismoNivelDePoder && mismaVelocidadNatacion && mismaComunicacionMarina)
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
