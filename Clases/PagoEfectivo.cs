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
        private readonly IEntradaConsola _entradaConsola;
        private readonly ISalidaConsola _salidaConsola;

        public PagoEfectivo(IEntradaConsola entradaConsola, ISalidaConsola salidaConsola)
        {
            _entradaConsola = entradaConsola;
            _salidaConsola = salidaConsola;
        }

        public bool ProcesarPago(decimal monto)
        {
            _salidaConsola.EscribirLinea($"\nMonto a pagar: S/{monto:F2}");
            _salidaConsola.Escribir("Ingrese la cantidad con la que paga: S/");
            decimal billete = _entradaConsola.LeerDecimal();

            if (billete >= monto)
            {
                decimal vuelto = billete - monto;
                _salidaConsola.EscribirLinea($"Pago en efectivo aceptado. Su vuelto es: S/{vuelto:F2}");
                return true;
            }

            _salidaConsola.EscribirLinea("El dinero entregado no alcanza.");
            return false;
        }
    }
}