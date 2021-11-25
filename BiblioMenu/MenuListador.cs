using System;
using System.Collections.Generic;

namespace et12.edu.ar.MenuesConsola
{
    /// <summary>
    /// Menu encargado de mostrar una colección
    /// </summary>
    /// <typeparam name="T">Tipo de la Coleccion</typeparam>
    public abstract class  MenuListador<T>: MenuComponente
    {
        /// <summary>
        /// Método encargado de mostrar por pantalla el listado de objetos T
        /// </summary>
        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine();
            mostrarListado(conIndice: false);
            Console.WriteLine("Presione una tecla para continuar ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Método que se encarga de mostrar por pantalla el listado de elementos
        /// </summary>
        /// <param name="conIndice">bool que indica si se desea mostrar con elementos con indice en base 0 o no</param>
        public void mostrarListado(bool conIndice = false)
        {
            var lista = obtenerLista();
            if (conIndice)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Console.Write($"{i}) ");
                    imprimirElemento(lista[i]);
                }
            }
            else
            {
                lista.ForEach(e => imprimirElemento(e));
            }
        }

        /// <summary>
        /// Método que se encarga de mostrar por pantalla un elemento del tipo T
        /// </summary>
        /// <param name="elemento">Parametro generico que se imprimirá</param>
        public abstract void imprimirElemento(T elemento);

        /// <summary>
        /// Método encargado de devolver el listado de lo que se quiere mostrar
        /// </summary>
        /// <returns>Colección de objetos a mostrar</returns>
        public abstract List<T> obtenerLista();

        /// <summary>
        /// Metodo encargado de mostrar el listado y de seleccionar un elemento
        /// </summary>
        /// <returns>Elemento seleccionado del tipo de la lista</returns>
        public T seleccionarElemento(bool valorObligatorio = true)
        {
            T seleccion = default(T);
            var lista = obtenerLista();
            mostrarListado(conIndice: true);
            byte indiceSeleccion;
            if (valorObligatorio)
            {
                indiceSeleccion = leerOpcion((byte)lista.Count);
                seleccion = lista[indiceSeleccion];
            }
            else
            {
                indiceSeleccion = leerOpcion((byte)(lista.Count+1));
            }            
            return seleccion;
        }
    }
}