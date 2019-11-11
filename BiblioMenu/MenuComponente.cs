using System;

namespace MenuesConsola
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