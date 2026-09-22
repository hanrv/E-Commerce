using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_07_09_2026.Clases
{
    internal interface IProducto
    {
        string Nombre { get; set; }
        decimal Precio { get; set; }
        int Cantidad { get; set; }

        decimal CalcularSubtotal();
        string ObtenerDetalle();
    }
}
