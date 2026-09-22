namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Interfaz para separar la lógica de validación de la clase Producto.
    /// PRINCIPIO SRP (Single Responsibility Principle): Cada clase tiene una única responsabilidad.
    /// La validación ahora es responsabilidad de esta interfaz, no de Producto.
    /// </summary>
    public interface IValidador
    {
        /// <summary>
        /// Valida si un valor es válido según las reglas del implementador.
        /// </summary>
        /// <param name="valor">El valor a validar</param>
        /// <returns>true si es válido, false en caso contrario</returns>
        bool EsValido(decimal valor);

        /// <summary>
        /// Obtiene el valor corregido si la validación falla.
        /// </summary>
        /// <param name="valor">El valor a corregir</param>
        /// <returns>El valor corregido o por defecto</returns>
        decimal ObtenerValorCorregido(decimal valor);

        /// <summary>
        /// Obtiene el mensaje de error cuando la validación falla.
        /// </summary>
        string ObtenerMensajeError();
    }
}
