using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Gestiona el menú de compra, el carrito y la selección del método de pago.
    /// </summary>
    public class MenuCompra
    {
        private readonly IEntradaConsola _entrada;
        private readonly ISalidaConsola _salida;
        private readonly IProductoFactory _productoFactory;

        public MenuCompra(
            IEntradaConsola entrada,
            ISalidaConsola salida,
            IProductoFactory productoFactory)
        {
            _entrada = entrada;
            _salida = salida;
            _productoFactory = productoFactory;
        }

        public void Ejecutar()
        {
            try
            {
                MostrarEjemplosLinq();
                EjecutarMenu();
            }
            catch (Exception ex)
            {
                _salida.EscribirLinea($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        private void EjecutarMenu()
        {
            List<Producto> carrito = new List<Producto>();
            string opcionElegida = string.Empty;

            while (opcionElegida != "0")
            {
                try
                {
                    MostrarMenuProductos();
                    opcionElegida = _entrada.LeerLinea().Trim().ToLower();

                    if (opcionElegida == "0")
                    {
                        break;
                    }

                    int cantidad = LeerCantidadValida();
                    AgregarProductoAlCarrito(carrito, opcionElegida, cantidad);
                    MostrarCarrito(carrito);
                }
                catch (ArgumentException ex)
                {
                    _salida.EscribirLinea($"Error de entrada: {ex.Message}");
                }
            }

            FinalizarCompra(carrito);
        }

        private void MostrarMenuProductos()
        {
            _salida.EscribirLinea("\n======= MENU =======");
            _salida.EscribirLinea("Catalogo de productos:");
            _salida.EscribirLinea("- Comidas: Hamburguesa(S/8.50), Empanada(S/5.50)");
            _salida.EscribirLinea("- Bebidas: Fanta(S/2.50), Frugos(S/3.00)");
            _salida.EscribirLinea("- Snacks: Cuates(S/1.00), Chetos(S/1.20)");
            _salida.EscribirLinea("Ingresa el producto a comprar:");
            _salida.EscribirLinea("Para salir y pagar presione 0");
        }

        private int LeerCantidadValida()
        {
            _salida.EscribirLinea("Ingrese la cantidad a comprar: ");
            int cantidad = (int)_entrada.LeerDecimal();

            if (cantidad <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor a 0.");
            }

            return cantidad;
        }

        private void AgregarProductoAlCarrito(List<Producto> carrito, string nombre, int cantidad)
        {
            Producto productoExistente = carrito.FirstOrDefault(
                item => item.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (productoExistente != null)
            {
                productoExistente.Cantidad += cantidad;
                _salida.EscribirLinea("Se sumo la cantidad al producto existente.");
                return;
            }

            Producto nuevoProducto = _productoFactory.CrearProducto(nombre, cantidad);

            if (nuevoProducto == null)
            {
                throw new ArgumentException("Ingrese un producto valido.", nameof(nombre));
            }

            carrito.Add(nuevoProducto);
        }

        private void MostrarCarrito(List<Producto> carrito)
        {
            decimal subtotalAcumulado = 0;

            _salida.EscribirLinea("\n==============================");
            _salida.EscribirLinea("     CARRITO DE COMPRAS       ");
            _salida.EscribirLinea("==============================");

            foreach (Producto item in carrito)
            {
                _salida.EscribirLinea(item.ObtenerDetalle());
                subtotalAcumulado += item.CalcularSubtotal();
            }

            _salida.EscribirLinea("------------------------------");
            _salida.EscribirLinea($"Total acumulado: S/{subtotalAcumulado:F2}");
            _salida.EscribirLinea("==============================");
        }

        private void FinalizarCompra(List<Producto> carrito)
        {
            if (carrito.Count == 0)
            {
                _salida.EscribirLinea("No se realizaron compras.");
                return;
            }

            decimal totalFinal = carrito.Sum(item => item.CalcularSubtotal());
            IPago formaDePago = SeleccionarMetodoDePago();

            if (formaDePago.ProcesarPago(totalFinal))
            {
                _salida.EscribirLinea("\n!Compra finalizada exitosamente!");
            }
        }

        private IPago SeleccionarMetodoDePago()
        {
            _salida.EscribirLinea("\nSeleccione el metodo de pago:");
            _salida.EscribirLinea("1. Efectivo");
            _salida.EscribirLinea("2. Tarjeta");
            _salida.Escribir("Opcion: ");
            string metodo = _entrada.LeerLinea().Trim();

            return metodo switch
            {
                "1" => new PagoEfectivo(_entrada, _salida),
                "2" => new PagoTarjeta(_entrada, _salida),
                _ => throw new ArgumentException("Metodo de pago invalido.", nameof(metodo))
            };
        }

        private void MostrarEjemplosLinq()
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

            _salida.EscribirLinea("\n========== CONSULTAS LINQ ==========");
            _salida.EscribirLinea("Where - Productos con precio mayor que 5:");
            foreach (Producto producto in productos.Where(producto => producto.Precio > 5))
            {
                _salida.EscribirLinea($"Nombre: {producto.Nombre}, Precio: S/{producto.Precio:F2}, Cantidad: {producto.Cantidad}");
            }

            _salida.EscribirLinea("Select - Nombres de los productos:");
            _salida.EscribirLinea(string.Join(", ", productos.Select(producto => producto.Nombre)));

            _salida.EscribirLinea("OrderBy - Ordenados por precio:");
            foreach (Producto producto in productos.OrderBy(producto => producto.Precio))
            {
                _salida.EscribirLinea($"Nombre: {producto.Nombre}, Precio: S/{producto.Precio:F2}, Cantidad: {producto.Cantidad}");
            }

            _salida.EscribirLinea("GroupBy - Agrupados por nombre:");
            foreach (IGrouping<string, Producto> grupo in productos.GroupBy(producto => producto.Nombre))
            {
                _salida.EscribirLinea($"{grupo.Key}: {grupo.Count()} productos");
            }

            _salida.EscribirLinea("====================================\n");
        }
    }
}
