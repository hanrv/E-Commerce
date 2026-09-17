using System;
using ConsoleApp_07_09_2026.Clases;

namespace ConsoleApp_07_09_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal montoTotal = 0;
            string opcionElegida = "";
            string historialPedidos = "";

            while (opcionElegida != "0")
            {
                Console.WriteLine("\n======= MENU ======");
                Console.WriteLine("Catalogo de productos:");
                Console.WriteLine("- Comidas: Hamburguesa(S/8.50), Empanada(S/5.50)");
                Console.WriteLine("- Bebidas: Fanta(S/2.50), Frugos(S/3.00)");
                Console.WriteLine("- Snacks: Cuates(S/1.00), Chetos(S/1.20)");
                Console.WriteLine("Ingresa el producto a comprar:");
                Console.WriteLine("Para salir presione 0");
                opcionElegida = Console.ReadLine();

                if (opcionElegida == "0")
                {
                    Console.WriteLine("Salida exitosa.");
                    break;
                }

                decimal precioUnitario = 0;
                bool productoValido = true;

                switch (opcionElegida)
                {
                    case "Hamburguesa":
                        precioUnitario = 8.50m;
                        break;
                    case "Empanada":
                        precioUnitario = 5.50m;
                        break;
                    case "Fanta":
                        precioUnitario = 2.50m;
                        break;
                    case "Frugos":
                        precioUnitario = 3.00m;
                        break;
                    case "Cuates":
                        precioUnitario = 1.00m;
                        break;
                    case "Chetos":
                        precioUnitario = 1.20m;
                        break;
                    default:
                        Console.WriteLine("Ingrese un producto valido.");
                        productoValido = false;
                        break;
                }

                if (!productoValido)
                {
                    continue;
                }

                Console.WriteLine("Ingrese la cantidad a comprar: ");
                int cantidadProductos = Convert.ToInt32(Console.ReadLine());

                Producto pedidoActual = new Producto(opcionElegida, precioUnitario, cantidadProductos);

                decimal subtotal = pedidoActual.calcularSubtotal();
                montoTotal += subtotal;
                historialPedidos += "(" + pedidoActual.Cantidad + ") " + pedidoActual.Nombre + ": S/" + subtotal + "\n";

                Console.WriteLine("\nCarrito de compras:");
                Console.WriteLine("Monto acumulado: S/" + montoTotal);

                if (historialPedidos == "")
                {
                    Console.WriteLine("No compraste nada");
                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Historial de Pedidos");
                    Console.WriteLine(historialPedidos);
                }
            }
        }
    }
}