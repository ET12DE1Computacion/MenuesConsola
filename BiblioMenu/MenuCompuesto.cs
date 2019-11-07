using System;
using System.Collections.Generic;

namespace MenuesConsola
{
    public class MenuCompuesto: MenuComponente
    {
        private List<MenuComponente> Menues { get; set; }
        public MenuCompuesto()
        {
            Menues = new List<MenuComponente>();
        }
        public MenuCompuesto(MenuComponente menu) : this()
        {
            Menues.Add(menu);
        }
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
        public void agregarMenu(MenuComponente menu) => Menues.Add(menu);
    }
}