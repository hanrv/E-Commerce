
// prueba c#
using System.Collections.Specialized;

double precHamburguesa = 8.50, precEmpanada = 5.50;
double precFanta = 2.5, precFrugos = 3.0;
double precCuates = 1.0, precChetos = 1.2;

double montoTotal = 0;

string opcionElegida = "";
string historialPedidos = "";
while (opcionElegida != "0")
{
    Console.WriteLine("\n=======MENU======");
    Console.WriteLine("Catalogo de productos:");
    Console.WriteLine("-Comidas: Hamburguesa(S/8.50), Empanada(S/5.50)");
    Console.WriteLine("-Bebidas: Fanta(S/2.50), Frugos(S/3.00)");
    Console.WriteLine("-Snacks: Cuates(S/1.00), Chetos(S/1.20)");
    Console.WriteLine("Ingresa el producto a comprar: ");
    Console.WriteLine("Para salir presione 0 ");
    opcionElegida = Console.ReadLine();

    if(opcionElegida == "0"){
        Console.WriteLine("Salida exitosa");
        break;
    }
    Console.WriteLine("Ingrese la cantidad a comprar: ");
    double cantCompra = Convert.ToDouble(Console.ReadLine());
    switch (opcionElegida)
    {
        case "Hamburguesa":
            montoTotal += precHamburguesa * cantCompra;
            historialPedidos += "(" + cantCompra + ") Hamburguesa: S/" + precHamburguesa * cantCompra + "\n";
            break;
        case "Empanada":    
            montoTotal += precEmpanada * cantCompra;
            historialPedidos += "(" + cantCompra + ") Empanada: S/" + precEmpanada * cantCompra + "\n";
            break;
        case "Fanta":                                           
            montoTotal += precFanta * cantCompra;
            historialPedidos += "(" + cantCompra + ") Fanta: S/" + precFanta * cantCompra + "\n";
            break;
        case "Frugos":
            montoTotal += precFrugos * cantCompra;
            historialPedidos += "(" + cantCompra + ") Frugos: S/" + precFrugos * cantCompra + "\n";
            break;
        case "Cuates":
            montoTotal += precCuates * cantCompra;
            historialPedidos += "(" + cantCompra + ") Cuates: S/" + precCuates * cantCompra + "\n";
            break;
        case "Chetos":
            montoTotal += precChetos * cantCompra;
            historialPedidos += "(" + cantCompra + ") Chetos: S/" + precChetos * cantCompra + "\n";
            break;
        default:
            Console.WriteLine("Ingrese un producto valido");
            break;
    }

    Console.WriteLine("\nCarrito de compras:");
    Console.WriteLine("Monto acumulado: S/" + montoTotal);

    if(historialPedidos == "") {
        Console.WriteLine("No compraste nada");
    }
    else
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Historial de Pedidos");
        Console.WriteLine(historialPedidos);
    }
}

