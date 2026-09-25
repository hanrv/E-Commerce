namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Interfaz compuesta para consumidores que necesitan leer y escribir.
    /// Las clases que solo requieren una de estas capacidades deben depender de
    /// IEntradaConsola o ISalidaConsola, aplicando el principio ISP.
    /// </summary>
    public interface ILectorConsola : IEntradaConsola, ISalidaConsola
    {
    }
}
