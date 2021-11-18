using System;

namespace et12.edu.ar.MenuesConsola
{
    /// <summary>
    /// Clase abstracta con la funcionalidad minima para los menues
    /// </summary>
    public abstract class MenuComponente
    {
        /// <summary>
        /// Nombre del menu, se utiliza tambien como Titulo
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MenuComponente(){}

        /// <summary>
        /// Constructor que recibe nombre por parametro
        /// </summary>
        /// <param name="nombre">Nombre del menu</param>
        public MenuComponente(string nombre)
        {
            Nombre = nombre;
        }

        /// <summary>
        /// Método base que se usa para mostrar el contenido del menu
        /// </summary>
        public virtual void mostrar()
        {
            limpiarConNombre();
        }

        /// <summary>
        /// Método que se encarga de limpiar la pantalla e imprime el nombre del menu
        /// </summary>
        public void limpiarConNombre()
        {
            Console.Clear();
            Console.WriteLine(Nombre);
        }

        /// <summary>
        /// Método que muestra un mensaje y espera leer una cadena
        /// </summary>
        /// <param name="cadena">Cadena que se desea mostrar, se la agrega ': '</param>
        /// <returns>string ingresado por el usuario en respuesta</returns>
        public string prompt(string cadena)
        {
            Console.Write(cadena + ": ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Método que muestra una pregunta cerrada y espera una respuesta
        /// </summary>
        /// <param name="cadena">Pregunta cerrada</param>
        /// <returns>Valor de verdad de la respuesta</returns>
        public bool preguntaCerrada(string cadena)
        {
            string opc;
            bool salida;

            do
            {
                Console.Write($"{cadena} S/N: ");
                opc = Console.ReadLine().ToUpper();
                salida = opc.CompareTo("S") == 0 || opc.CompareTo("N") == 0;
                if (!salida)
                {
                    Console.WriteLine("Por favor seleccione una opción valida: S o N");
                }
            } while (!salida);

            return opc.CompareTo("S") == 0;
        }

        /// <summary>
        /// Método que lee un valor numerico por debajo de la cantidad de opciones
        /// </summary>
        /// <param name="cantOpciones">Cantidad maxima de opciones a elegir</param>
        /// <returns>Devuelve la opcion seleccionada, comprendida entre 0 y <c>cantOpciones</c></returns>
        public byte leerOpcion(byte cantOpciones)
        {
            byte opc;
            var fueraRango = $"Valor fuera de rango, seleccione un valor adecuado entre 0 y {cantOpciones}";
            do
            {
                try
                {
                    opc = Convert.ToByte(prompt("Seleccione una opción"));
                    if (opc > cantOpciones)
                    {
                        Console.WriteLine(fueraRango);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato no valido, seleccione solo numeros");
                }
                catch (OverflowException)
                {
                    Console.WriteLine(fueraRango);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocurrio un error inesperado: " + e.Message);
                }
            } while (true);
            return opc;
        }
    }
}