using System;
using System.Collections.Generic;
using ConsoleApp_07_09_2026.Clases;

namespace ConsoleApp_07_09_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IProducto> carrito = new List<IProducto>();
            string opcionElegida = "";

            while (opcionElegida != "0")
            {
                Console.WriteLine("\n======= MENU ======");
                Console.WriteLine("Catalogo de productos:");
                Console.WriteLine("- Comidas: Hamburguesa(S/8.50), Empanada(S/5.50)");
                Console.WriteLine("- Bebidas: Fanta(S/2.50), Frugos(S/3.00)");
                Console.WriteLine("- Snacks: Cuates(S/1.00), Chetos(S/1.20)");
                Console.WriteLine("Ingresa el producto a comprar:");
                Console.WriteLine("Para salir presione 0");

                opcionElegida = Console.ReadLine().ToLower();

                if (opcionElegida == "0")
                {
                    Console.WriteLine("Salida exitosa.");
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

                foreach (IProducto item in carrito)
                {
                    if (item.Nombre.ToLower() == opcionElegida)
                    {
                        item.Cantidad += cantidad;
                        encontrado = true;
                        Console.WriteLine("Se agrego cantidad al producto existente.");
                        break;
                    }
                }

                if (!encontrado)
                {
                    IProducto nuevoProducto = null;

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

                decimal total = 0;
                Console.WriteLine("\n==============================");
                Console.WriteLine("     CARRITO DE COMPRAS       ");
                Console.WriteLine("==============================");

                foreach (IProducto item in carrito)
                {
                    Console.WriteLine(item.ObtenerDetalle());
                    total += item.CalcularSubtotal();
                }

                Console.WriteLine("------------------------------");
                Console.WriteLine("Total acumulado: S/" + total);
                Console.WriteLine("==============================");
            }
        }
    }
}