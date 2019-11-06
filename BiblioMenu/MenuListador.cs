using System;
using System.Collections.Generic;

namespace MenuesConsola
{
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
        public abstract void imprimirElemento(T elemento);
        public abstract List<T> obtenerLista();
        public T seleccionarElemento()
        {
            var lista = obtenerLista();
            mostrarListado(conIndice: true);
            var indiceSeleccion = leerOpcion((byte)lista.Count);
            return lista[indiceSeleccion];
        }
    }
}