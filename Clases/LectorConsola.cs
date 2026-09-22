using System;
using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Implementación concreta de ILectorConsola que interactúa con Console.
    /// PRINCIPIO DIP (Dependency Inversion Principle): Esta clase implementa la interfaz
    /// y encapsula los detalles de cómo se leen/escriben los datos desde/a la consola.
    /// Otras clases dependerán de la interfaz, no de esta implementación directa.
    /// </summary>
    public class LectorConsola : ILectorConsola
    {
        public string LeerLinea()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public decimal LeerDecimal()
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal resultado))
            {
                return resultado;
            }
            return 0;
        }

        public void Escribir(string mensaje)
        {
            Console.Write(mensaje);
        }

        public void EscribirLinea(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
