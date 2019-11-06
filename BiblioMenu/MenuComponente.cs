using System;

namespace MenuesConsola
{
    public abstract class MenuComponente
    {
        public string Nombre { get; set; }
        public virtual void mostrar()
        {
            Console.Clear();
            Console.WriteLine(Nombre);
        }
        public string prompt(string cadena)
        {
            Console.Write(cadena + ": ");
            return Console.ReadLine();
        }
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