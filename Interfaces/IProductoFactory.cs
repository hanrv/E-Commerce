using ConsoleApp_07_09_2026.Clases;

namespace ConsoleApp_07_09_2026.Interfaces
{
    /// <summary>
    /// Interfaz Factory para crear productos sin acoplarse a sus implementaciones concretas.
    /// PRINCIPIO OCP (Open/Closed Principle): El sistema esta abierto a extension (nuevos productos)
    /// pero cerrado a modificacion (Program.cs no necesita cambiar si se agregan nuevos productos).
    /// </summary>
    public interface IProductoFactory
    {
        /// <summary>
        /// Crea un producto basado en el nombre proporcionado.
        /// </summary>
        /// <param name="nombre">El nombre del producto</param>
        /// <param name="cantidad">La cantidad a crear</param>
        /// <returns>Una instancia de Producto, o null si no se reconoce el nombre</returns>
        Producto CrearProducto(string nombre, int cantidad);
    }
}
