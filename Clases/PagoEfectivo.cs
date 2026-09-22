using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Procesa pagos en efectivo.
    /// PRINCIPIO DIP (Dependency Inversion Principle): Depende de ILectorConsola, no de Console directamente.
    /// Esto permite testear y cambiar la implementación sin afectar esta clase.
    /// </summary>
    public class PagoEfectivo : IPago
    {
        private readonly ILectorConsola _lectorConsola;

        public PagoEfectivo(ILectorConsola lectorConsola)
        {
            _lectorConsola = lectorConsola;
        }

        public bool ProcesarPago(decimal monto)
        {
            _lectorConsola.EscribirLinea($"\nMonto a pagar: S/{monto:F2}");
            _lectorConsola.Escribir("Ingrese la cantidad con la que paga: S/");
            decimal billete = _lectorConsola.LeerDecimal();

            if (billete >= monto)
            {
                decimal vuelto = billete - monto;
                _lectorConsola.EscribirLinea($"Pago en efectivo aceptado. Su vuelto es: S/{vuelto:F2}");
                return true;
            }

            _lectorConsola.EscribirLinea("El dinero entregado no alcanza.");
            return false;
        }
    }
}