using System;
using ConsoleApp_07_09_2026.Clases;

namespace ConsoleApp_07_09_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lectorConsola = new LectorConsola();

            try
            {
                var menuCompra = new MenuCompra(
                    lectorConsola,
                    lectorConsola,
                    new ProductoFactory());

                menuCompra.Ejecutar();
            }
            catch (Exception ex)
            {
                lectorConsola.EscribirLinea($"La aplicación finalizó por un error: {ex.Message}");
            }
        }
    }
}
