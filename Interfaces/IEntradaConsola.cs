namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Define únicamente las operaciones de entrada de la consola.
    /// PRINCIPIO ISP (Interface Segregation Principle): Los consumidores que
    /// solo necesitan leer no dependen de operaciones de escritura.
    /// </summary>
    public interface IEntradaConsola
    {
        string LeerLinea();
        decimal LeerDecimal();
    }
}
