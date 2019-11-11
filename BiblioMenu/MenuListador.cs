using System;
using System.Collections.Generic;

namespace MenuesConsola
{
    /// <summary>
    /// Menu encargado de mostrar una colección
    /// </summary>
    /// <typeparam name="T">Tipo de la Coleccion</typeparam>
    public abstract class  MenuListador<T>: MenuComponente
    {
        public override void mostrar()
        {
            base.mostrar();
            Console.WriteLine();
            mostrarListado(conIndice: false);
            Console.WriteLine("Presione una tecla para continuar ...");
            Console.ReadKey();
        }
        private void mostrarListado(bool conIndice = false)
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
        public T seleccionarElemento()
        {
            var lista = obtenerLista();
            mostrarListado(conIndice: true);
            var indiceSeleccion = leerOpcion((byte)lista.Count);
            return lista[indiceSeleccion];
        }
    }
}