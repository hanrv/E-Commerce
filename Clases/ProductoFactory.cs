using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Factory que centraliza la creación de productos.
    /// PRINCIPIO OCP (Open/Closed Principle): La lógica de creación está centralizada.
    /// Para agregar nuevos productos, solo se modifica esta clase (o se extiende),
    /// sin tocar Program.cs (cerrado a modificación).
    /// </summary>
    public class ProductoFactory : IProductoFactory
    {
        public Producto CrearProducto(string nombre, int cantidad)
        {
            return nombre.ToLower() switch
            {
                "hamburguesa" => new Comida("Hamburguesa", 8.50m, cantidad, true),
                "empanada" => new Comida("Empanada", 5.50m, cantidad, true),
                "fanta" => new Bebida("Fanta", 2.50m, cantidad, 500),
                "frugos" => new Bebida("Frugos", 3.00m, cantidad, 300),
                "cuates" => new Snack("Cuates", 1.00m, cantidad, 45),
                "chetos" => new Snack("Chetos", 1.20m, cantidad, 38),
                _ => null
            };
        }
    }
}
