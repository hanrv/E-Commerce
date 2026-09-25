namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Define únicamente las operaciones de salida de la consola.
    /// PRINCIPIO ISP (Interface Segregation Principle): Los consumidores que
    /// solo necesitan escribir no dependen de operaciones de lectura.
    /// </summary>
    public interface ISalidaConsola
    {
        void Escribir(string mensaje);
        void EscribirLinea(string mensaje);
    }
}
