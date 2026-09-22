namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Interfaz para abstraer la lectura de entrada del usuario desde la consola.
    /// PRINCIPIO DIP (Dependency Inversion Principle): Las clases dependen de abstracciones,
    /// no de implementaciones concretas como Console.ReadLine().
    /// Esto permite cambiar la fuente de entrada sin modificar las clases que la usan.
    /// </summary>
    public interface ILectorConsola
    {
        /// <summary>
        /// Lee una línea de texto desde la consola.
        /// </summary>
        /// <returns>La línea ingresada por el usuario</returns>
        string LeerLinea();

        /// <summary>
        /// Lee un número decimal desde la consola.
        /// </summary>
        /// <returns>El número decimal ingresado</returns>
        decimal LeerDecimal();

        /// <summary>
        /// Escribe texto en la consola.
        /// </summary>
        /// <param name="mensaje">El mensaje a escribir</param>
        void Escribir(string mensaje);

        /// <summary>
        /// Escribe una línea de texto en la consola.
        /// </summary>
        /// <param name="mensaje">El mensaje a escribir</param>
        void EscribirLinea(string mensaje);
    }
}
