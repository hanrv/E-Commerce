using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Procesa pagos con tarjeta de crédito.
    /// PRINCIPIO DIP (Dependency Inversion Principle): Depende de ILectorConsola, no de Console directamente.
    /// Esto permite cambiar la fuente de entrada sin modificar esta clase.
    /// </summary>
    public class PagoTarjeta : IPago
    {
        private readonly ILectorConsola _lectorConsola;

        public PagoTarjeta(ILectorConsola lectorConsola)
        {
            _lectorConsola = lectorConsola;
        }

        public bool ProcesarPago(decimal monto)
        {
            _lectorConsola.EscribirLinea($"\nMonto a cobrar en tarjeta: S/{monto:F2}");
            _lectorConsola.Escribir("Ingrese los 16 dígitos de su tarjeta: ");
            string tarjeta = _lectorConsola.LeerLinea();

            if (tarjeta.Length == 16)
            {
                _lectorConsola.EscribirLinea("Conectando con el banco... ¡Cobro aprobado!");
                return true;
            }

            _lectorConsola.EscribirLinea("Número de tarjeta inválido.");
            return false;
        }
    }
}