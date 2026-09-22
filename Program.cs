using System;
using System.Collections.Generic;
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
    }
}
