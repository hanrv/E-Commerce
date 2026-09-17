using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp_07_09_2026.Clases
{
    internal class Producto
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }

            set { _nombre = value; }
        }

        private decimal _precio;
        public decimal Precio
        {
            get { return _precio; }
            set {
                if (value < 0)
                {
                    Console.WriteLine("Ingrese un precio mayor que 0. Se aginara el valor de 0");
                    _precio = 0;
                    return;
                }
                else
                {
                    _precio = value;
                }
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ingrese una cantidad mayor que 0. Se aginara el valor de 0");
                    _cantidad = 0;
                    return;
                }
                else
                {
                    _cantidad = value;
                }

            }
        }

        public Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public decimal calcularSubtotal()
        {
            return Precio * Cantidad;
        }
    }
}
