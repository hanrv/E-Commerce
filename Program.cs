using System;
using System.Collections.Generic;
using ConsoleApp_07_09_2026.Clases;

namespace ConsoleApp_07_09_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> carrito = new List<Producto>();
            string opcionElegida = "";

            while (opcionElegida != "0")
            {
                Console.WriteLine("\n======= MENU ======");
                Console.WriteLine("Catalogo de productos:");
                Console.WriteLine("- Comidas: Hamburguesa(S/8.50), Empanada(S/5.50)");
                Console.WriteLine("- Bebidas: Fanta(S/2.50), Frugos(S/3.00)");
                Console.WriteLine("- Snacks: Cuates(S/1.00), Chetos(S/1.20)");
                Console.WriteLine("Ingresa el producto a comprar:");
                Console.WriteLine("Para salir y pagar presione 0");

                opcionElegida = Console.ReadLine().Trim().ToLower();

                if (opcionElegida == "0")
                {
                    break;
                }

                Console.WriteLine("Ingrese la cantidad a comprar: ");
                int cantidad = Convert.ToInt32(Console.ReadLine());

                if (cantidad <= 0)
                {
                    Console.WriteLine("La cantidad debe ser mayor a 0.");
                    continue;
                }

                bool encontrado = false;
                foreach (Producto item in carrito)
                {
                    if (item.Nombre.ToLower() == opcionElegida)
                    {
                        item.Cantidad += cantidad;
                        encontrado = true;
                        Console.WriteLine("Se sumó la cantidad al producto existente.");
                        break;
                    }
                }

                if (!encontrado)
                {
                    Producto nuevoProducto = null;

                    switch (opcionElegida)
                    {
                        case "hamburguesa":
                            nuevoProducto = new Comida("Hamburguesa", 8.50m, cantidad, true);
                            break;
                        case "empanada":
                            nuevoProducto = new Comida("Empanada", 5.50m, cantidad, true);
                            break;
                        case "fanta":
                            nuevoProducto = new Bebida("Fanta", 2.50m, cantidad, 500);
                            break;
                        case "frugos":
                            nuevoProducto = new Bebida("Frugos", 3.00m, cantidad, 300);
                            break;
                        case "cuates":
                            nuevoProducto = new Snack("Cuates", 1.00m, cantidad, 45);
                            break;
                        case "chetos":
                            nuevoProducto = new Snack("Chetos", 1.20m, cantidad, 38);
                            break;
                        default:
                            Console.WriteLine("Ingrese un producto valido.");
                            break;
                    }

                    if (nuevoProducto != null)
                    {
                        carrito.Add(nuevoProducto);
                    }
                }

                decimal subtotalAcumulado = 0;
                Console.WriteLine("\n==============================");
                Console.WriteLine("     CARRITO DE COMPRAS       ");
                Console.WriteLine("==============================");

                foreach (Producto item in carrito)
                {
                    Console.WriteLine(item.ObtenerDetalle());
                    subtotalAcumulado += item.CalcularSubtotal();
                }

                Console.WriteLine("------------------------------");
                Console.WriteLine($"Total acumulado: S/{subtotalAcumulado:F2}");
                Console.WriteLine("==============================");
            }

            if (carrito.Count > 0)
            {
                decimal totalFinal = 0;
                foreach (Producto item in carrito)
                {
                    totalFinal += item.CalcularSubtotal();
                }

                Console.WriteLine("\nSeleccione el método de pago:");
                Console.WriteLine("1. Efectivo");
                Console.WriteLine("2. Tarjeta");
                Console.Write("Opción: ");
                string metodo = Console.ReadLine().Trim();

                IPago formaDePago = null;

                if (metodo == "1")
                {
                    formaDePago = new PagoEfectivo();
                }
                else if (metodo == "2")
                {
                    formaDePago = new PagoTarjeta();
                }
                else
                {
                    Console.WriteLine("Método inválido.");
                    return;
                }

                bool exito = formaDePago.ProcesarPago(totalFinal);

                if (exito)
                {
                    Console.WriteLine("\n¡Compra finalizada exitosamente!");
                }
            }
            else
            {
                Console.WriteLine("No se realizaron compras.");
            }
        }
    }
}