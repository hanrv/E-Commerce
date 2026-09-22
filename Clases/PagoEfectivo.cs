using System;

namespace ConsoleApp_07_09_2026.Clases
{
    public class PagoEfectivo : IPago
    {
        public bool ProcesarPago(decimal monto)
        {
            Console.WriteLine($"\nMonto a pagar: S/{monto:F2}");
            Console.Write("Ingrese la cantidad con la que paga: S/");
            decimal billete = Convert.ToDecimal(Console.ReadLine());

            if (billete >= monto)
            {
                decimal vuelto = billete - monto;
                Console.WriteLine($"Pago en efectivo aceptado. Su vuelto es: S/{vuelto:F2}");
                return true;
            }

            Console.WriteLine("El dinero entregado no alcanza.");
            return false;
        }
    }
}