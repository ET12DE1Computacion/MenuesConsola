using System;
using System.Collections.Generic;

namespace MenuesConsola
{
    /// <summary>
    /// Menu encargado de mostrar y seleccionar otros menues
    /// </summary>
    public class MenuCompuesto: MenuComponente
    {
        private List<MenuComponente> Menues { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MenuCompuesto()
        {
            Menues = new List<MenuComponente>();
        }

        /// <summary>
        /// Constructor que inicializa su listado con un MenuComponente
        /// </summary>
        /// <param name="menu">Elemento que se agregara a la lista de menues</param>
        public MenuCompuesto(MenuComponente menu) : this()
        {
            Menues.Add(menu);
        }

        /// <summary>
        /// Constructor que inicializa su listado de menues en base a otro
        /// </summary>
        /// <param name="menues">Lista de Menues para el MenuCompuesto</param>
        public MenuCompuesto(List<MenuComponente> menues)
        {
            Menues = menues;
        }

        /// <summary>
        /// Método encargado de mostrar y seleccionar los menues que lo componen
        /// </summary>
        public override void mostrar()
        {
            byte opcion;
            do
            {
                imprimirMenues();
                Console.WriteLine();
                opcion = leerOpcion((byte)Menues.Count);
                if (opcion < Menues.Count)
                {
                    Menues[opcion].mostrar();
                }
                else
                {
                    break;
                }
            } while (true);
        }
        private void imprimirMenues()
        {
            base.mostrar();
            byte i;            
            Console.WriteLine();
            for (i = 0; i < Menues.Count; i++)
            {
                Console.WriteLine($"{i}) {Menues[i].Nombre}");
            }
            Console.WriteLine(i + ") Salir");
        }

        /// <summary>
        /// Método que permite agregar menues de forma dinamica
        /// </summary>
        /// <param name="menu">Menu que se desea agregar</param>
        public void agregarMenu(MenuComponente menu) => Menues.Add(menu);
    }
}