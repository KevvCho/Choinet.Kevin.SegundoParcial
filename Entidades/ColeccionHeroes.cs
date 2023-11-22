using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ColeccionHeroes<T> where T : Heroe
    {
        private List<T> heroes;

        public ColeccionHeroes()
        {
            heroes = new List<T>();
            SuscribirMetodos();
        }

        public event EventHandler<T> HeroeAgregado;
        public event EventHandler<T> HeroeEliminado;


        /// <summary>
        /// Se asegura de saber si el heroe se encuentra en la lista y lo agrega
        /// </summary>
        public void AgregarHeroe(T heroe)
        {
            if (!heroes.Contains(heroe))
            {
                heroes.Add(heroe);

                OnHeroeAgregado(heroe);
            }
        }

        protected virtual void OnHeroeAgregado(T heroe)
        {
            HeroeAgregado?.Invoke(this, heroe);
        }
        /// <summary>
        /// Se verifica si el heroe esta en la lista y se elimina
        /// </summary>
        public void EliminarHeroe(T heroe)
        {
            if (heroes.Contains(heroe))
            {
                heroes.Remove(heroe);

                OnHeroeEliminado(heroe);
            }
        }
        protected virtual void OnHeroeEliminado(T heroe)
        {
            HeroeEliminado?.Invoke(this, heroe);
        }

        public void SuscribirMetodos()
        {
            HeroeAgregado += (sender, heroe) => Console.WriteLine($"Se ha agregado un heroe a la colección.");
            HeroeEliminado += (sender, heroe) => Console.WriteLine($"Se ha eliminado un heroe de la colección.");
        }

        /// <summary>
        /// Utilizacion de IEnumerator para listas genericas
        /// </summary>
        /// <returns>Permite a la lista generica ser recorrida en un bucle foreach</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return heroes.GetEnumerator();
        }

        /// <summary>
        /// A diferencia de Contains, se asegura de comprobar a partir del nombre en vez de por objeto tipo Heroe
        /// </summary>
        public bool ContieneHeroe(string nombreHeroe)
        {
            return heroes.Any(heroe => heroe.Nombre == nombreHeroe);
        }
        /// <summary>
        /// Ordena la lista de forma ascendente o descendente por nivel de poder base
        /// </summary>
        /// <param name="ascendente">Dependiendo de el booleano cambia el orden</param>
        /// <returns></returns>
        public ColeccionHeroes<T> OrdenarPorNivelDePoder(bool ascendente)
        {
            List<T> listaOrdenada;
            if (ascendente)
            {
                listaOrdenada = heroes.OrderBy(h => h.NivelDePoder).ToList();
            }
            else
            {
                listaOrdenada = heroes.OrderByDescending(h => h.NivelDePoder).ToList();
            }

            ColeccionHeroes<T> coleccionOrdenada = new ColeccionHeroes<T>();
            coleccionOrdenada.heroes = listaOrdenada;
            return coleccionOrdenada;
        }
        /// <summary>
        /// Ordena la lista de forma ascendente o descendente alfabeticamente por nombre
        /// </summary>
        /// <param name="ascendente">Dependiendo de el booleano cambia el orden</param>
        /// <returns></returns>
        public ColeccionHeroes<T> OrdenarPorNombre(bool ascendente)
        {
            List<T> listaOrdenada;
            if (ascendente)
            {
                listaOrdenada = heroes.OrderBy(h => h.Nombre).ToList();
            }
            else
            {
                listaOrdenada = heroes.OrderByDescending(h => h.Nombre).ToList();
            }

            ColeccionHeroes<T> coleccionOrdenada = new ColeccionHeroes<T>();
            coleccionOrdenada.heroes = listaOrdenada;
            return coleccionOrdenada;
        }
        /// <summary>
        /// A partir de la lista comprueba mediante expresion lambda aquel heroe con ese nombre
        /// </summary>
        /// <param name="nombreHeroe">Nombre del heroe a buscar en la lista</param>
        /// <returns>Retorna el heroe en esa lista que tenga el mismo nombre</returns>
        public Heroe ObtenerHeroe(string nombreHeroe)
        {
            return heroes.FirstOrDefault(heroe => heroe.Nombre == nombreHeroe);
        }
        /// <summary>
        /// Operador para agregar heroes a la lista generica
        /// </summary>
        /// <param name="coleccion">Coleccion a la cual se le agrega un heroe</param>
        /// <param name="heroe">Heroe de cualquier tipo</param>
        /// <returns>Retorna la lista con el heroe agregado</returns>
        public static ColeccionHeroes<T> operator +(ColeccionHeroes<T> coleccion, T heroe)
        {
            coleccion.AgregarHeroe(heroe);
            return coleccion;
        }
        /// <summary>
        /// Operador para eliminar heroes de la lista
        /// </summary>
        /// <param name="coleccion">Coleccion de la que se elimina el heroe</param>
        /// <param name="heroe">Heroe de cualquier tipo</param>
        /// <returns>Retorna la lista luego de remover el heroe</returns>
        public static ColeccionHeroes<T> operator -(ColeccionHeroes<T> coleccion, T heroe)
        {
            coleccion.EliminarHeroe(heroe);
            return coleccion;
        }
        /// <summary>
        /// Operador de igualdad para saber si el heroe se encuentra en la lista
        /// </summary>
        public static bool operator ==(ColeccionHeroes<T> coleccion, T heroe)
        {
            return coleccion.ContieneHeroe(heroe);
        }
        /// <summary>
        /// Operador de desigualdad para comprobar que el heroe no esta en la lista
        /// </summary>
        public static bool operator !=(ColeccionHeroes<T> coleccion, T heroe)
        {
            return !coleccion.ContieneHeroe(heroe);
        }



    }
}
