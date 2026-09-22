using System;

namespace ConsoleApp_07_09_2026.Clases
{
    public class PagoTarjeta : IPago
    {
        public bool ProcesarPago(decimal monto)
        {
            Console.WriteLine($"\nMonto a cobrar en tarjeta: S/{monto:F2}");
            Console.Write("Ingrese los 16 dígitos de su tarjeta: ");
            string tarjeta = Console.ReadLine();

            if (tarjeta.Length == 16)
            {
                Console.WriteLine("Conectando con el banco... ¡Cobro aprobado!");
                return true;
            }

            Console.WriteLine("Número de tarjeta inválido.");
            return false;
        }
    }
}