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
        private readonly IEntradaConsola _entradaConsola;
        private readonly ISalidaConsola _salidaConsola;

        public PagoTarjeta(IEntradaConsola entradaConsola, ISalidaConsola salidaConsola)
        {
            _entradaConsola = entradaConsola;
            _salidaConsola = salidaConsola;
        }

        public bool ProcesarPago(decimal monto)
        {
            _salidaConsola.EscribirLinea($"\nMonto a cobrar en tarjeta: S/{monto:F2}");
            _salidaConsola.Escribir("Ingrese los 16 dígitos de su tarjeta: ");
            string tarjeta = _entradaConsola.LeerLinea();

            if (tarjeta.Length == 16)
            {
                _salidaConsola.EscribirLinea("Conectando con el banco... ¡Cobro aprobado!");
                return true;
            }

            _salidaConsola.EscribirLinea("Número de tarjeta inválido.");
            return false;
        }
    }
}