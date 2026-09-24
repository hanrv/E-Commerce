using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp_07_09_2026.Clases;
using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026
{
    /// <summary>
    /// Programa principal que gestiona el carrito de compras.
    /// PRINCIPIO DIP (Dependency Inversion Principle): Depende de interfaces (ILectorConsola, IProductoFactory, IPago)
    /// y no de clases concretas, permitiendo cambios sin modificar este codigo.
    /// PRINCIPIO OCP (Open/Closed Principle): Puede agregar nuevos tipos de pago o productos sin cambiar este codigo.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            MostrarEjemplosLinq();

            // PRINCIPIO DIP: Se inyectan las dependencias
            var lectorConsola = new LectorConsola();
            var productoFactory = new ProductoFactory();

            List<Producto> carrito = new List<Producto>();
            string opcionElegida = "";

            while (opcionElegida != "0")
            {
                lectorConsola.EscribirLinea("\n======= MENU =======");
                lectorConsola.EscribirLinea("Catalogo de productos:");
                lectorConsola.EscribirLinea("- Comidas: Hamburguesa(S/8.50), Empanada(S/5.50)");
                lectorConsola.EscribirLinea("- Bebidas: Fanta(S/2.50), Frugos(S/3.00)");
                lectorConsola.EscribirLinea("- Snacks: Cuates(S/1.00), Chetos(S/1.20)");
                lectorConsola.EscribirLinea("Ingresa el producto a comprar:");
                lectorConsola.EscribirLinea("Para salir y pagar presione 0");

                opcionElegida = lectorConsola.LeerLinea().Trim().ToLower();

                if (opcionElegida == "0")
                {
                    break;
                }

                lectorConsola.EscribirLinea("Ingrese la cantidad a comprar: ");
                int cantidad = (int)lectorConsola.LeerDecimal();

                if (cantidad <= 0)
                {
                    lectorConsola.EscribirLinea("La cantidad debe ser mayor a 0.");
                    continue;
                }

                bool encontrado = false;
                foreach (Producto item in carrito)
                {
                    if (item.Nombre.ToLower() == opcionElegida)
                    {
                        item.Cantidad += cantidad;
                        encontrado = true;
                        lectorConsola.EscribirLinea("Se sumo la cantidad al producto existente.");
                        break;
                    }
                }

                if (!encontrado)
                {
                    // PRINCIPIO OCP: La creacion de productos es delegada a la Factory
                    Producto nuevoProducto = productoFactory.CrearProducto(opcionElegida, cantidad);

                    if (nuevoProducto != null)
                    {
                        carrito.Add(nuevoProducto);
                    }
                    else
                    {
                        lectorConsola.EscribirLinea("Ingrese un producto valido.");
                    }
                }

                decimal subtotalAcumulado = 0;
                lectorConsola.EscribirLinea("\n==============================");
                lectorConsola.EscribirLinea("     CARRITO DE COMPRAS       ");
                lectorConsola.EscribirLinea("==============================");

                foreach (Producto item in carrito)
                {
                    lectorConsola.EscribirLinea(item.ObtenerDetalle());
                    subtotalAcumulado += item.CalcularSubtotal();
                }

                lectorConsola.EscribirLinea("------------------------------");
                lectorConsola.EscribirLinea($"Total acumulado: S/{subtotalAcumulado:F2}");
                lectorConsola.EscribirLinea("==============================");
            }

            if (carrito.Count > 0)
            {
                decimal totalFinal = 0;
                foreach (Producto item in carrito)
                {
                    totalFinal += item.CalcularSubtotal();
                }

                lectorConsola.EscribirLinea("\nSeleccione el metodo de pago:");
                lectorConsola.EscribirLinea("1. Efectivo");
                lectorConsola.EscribirLinea("2. Tarjeta");
                lectorConsola.Escribir("Opcion: ");
                string metodo = lectorConsola.LeerLinea().Trim();

                // PRINCIPIO DIP: Se crea la forma de pago inyectando la dependencia
                IPago formaDePago = null;

                if (metodo == "1")
                {
                    formaDePago = new PagoEfectivo(lectorConsola);
                }
                else if (metodo == "2")
                {
                    formaDePago = new PagoTarjeta(lectorConsola);
                }
                else
                {
                    lectorConsola.EscribirLinea("Metodo invalido.");
                    return;
                }

                bool exito = formaDePago.ProcesarPago(totalFinal);

                if (exito)
                {
                    lectorConsola.EscribirLinea("\n!Compra finalizada exitosamente!");
                }
            }
            else
            {
                lectorConsola.EscribirLinea("No se realizaron compras.");
            }
        }

        private static void MostrarEjemplosLinq()
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto("Pan", 1.50m, 2),
                new Producto("Leche", 4.00m, 1),
                new Producto("Arroz", 5.50m, 3),
                new Producto("Azucar", 4.50m, 2),
                new Producto("Cafe", 8.00m, 1),
                new Producto("Fideos", 3.50m, 4),
                new Producto("Atun", 6.00m, 2),
                new Producto("Galletas", 2.50m, 5),
                new Producto("Queso", 9.00m, 1),
                new Producto("Jamon", 10.00m, 2),
                new Producto("Pan", 1.50m, 3),
                new Producto("Leche", 4.00m, 2),
                new Producto("Arroz", 5.50m, 1),
                new Producto("Azucar", 4.50m, 4),
                new Producto("Cafe", 8.00m, 2),
                new Producto("Fideos", 3.50m, 1),
                new Producto("Atun", 6.00m, 3),
                new Producto("Galletas", 2.50m, 2),
                new Producto("Queso", 9.00m, 2),
                new Producto("Jamon", 10.00m, 1)
            };

            Console.WriteLine("\n========== CONSULTAS LINQ ==========");

            // WHERE 1: productos con precio mayor que 5.
            var where1 = productos.Where(producto => producto.Precio > 5);
            Console.WriteLine("Where 1 - Productos con precio mayor que 5:");
            foreach (var producto in where1)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: S/{producto.Precio:F2}, Cantidad: {producto.Cantidad}");
            }

            // WHERE 2: productos con cantidad mayor que 2.
            var where2 = productos.Where(producto => producto.Cantidad > 2);
            Console.WriteLine("Where 2 - Productos con cantidad mayor que 2:");
            foreach (var producto in where2)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: S/{producto.Precio:F2}, Cantidad: {producto.Cantidad}");
            }

            // SELECT 1: obtener solo los nombres.
            var select1 = productos.Select(producto => producto.Nombre);
            Console.WriteLine("Select 1 - Nombres de los productos:");
            Console.WriteLine(string.Join(", ", select1));

            // SELECT 2: obtener nombre y precio.
            var select2 = productos.Select(producto => $"{producto.Nombre}: S/{producto.Precio:F2}");
            Console.WriteLine("Select 2 - Nombre y precio:");
            Console.WriteLine(string.Join(", ", select2));

            // ORDERBY 1: ordenar por precio de menor a mayor.
            var orderBy1 = productos.OrderBy(producto => producto.Precio);
            Console.WriteLine("OrderBy 1 - Ordenados por precio:");
            foreach (var producto in orderBy1)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: S/{producto.Precio:F2}, Cantidad: {producto.Cantidad}");
            }

            // ORDERBY 2: ordenar por cantidad de mayor a menor.
            var orderBy2 = productos.OrderByDescending(producto => producto.Cantidad);
            Console.WriteLine("OrderBy 2 - Ordenados por cantidad:");
            foreach (var producto in orderBy2)
            {
                Console.WriteLine($"Nombre: {producto.Nombre}, Precio: S/{producto.Precio:F2}, Cantidad: {producto.Cantidad}");
            }

            // GROUPBY 1: agrupar por nombre.
            var groupBy1 = productos.GroupBy(producto => producto.Nombre);
            Console.WriteLine("GroupBy 1 - Agrupados por nombre:");
            foreach (var grupo in groupBy1)
            {
                Console.WriteLine($"{grupo.Key}: {grupo.Count()} productos");
            }

            // GROUPBY 2: agrupar por precio.
            var groupBy2 = productos.GroupBy(producto => producto.Precio);
            Console.WriteLine("GroupBy 2 - Agrupados por precio:");
            foreach (var grupo in groupBy2)
            {
                Console.WriteLine($"S/{grupo.Key:F2}: {grupo.Count()} productos");
            }

            Console.WriteLine("====================================\n");
        }
    }
}
