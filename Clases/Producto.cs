using System;

namespace ConsoleApp_07_09_2026.Clases
{
    public class Producto
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
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("El precio no puede ser negativo. Se asignará 0.");
                    _precio = 0;
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
                    Console.WriteLine("La cantidad no puede ser negativa. Se asignará 0.");
                    _cantidad = 0;
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

        public decimal CalcularSubtotal()
        {
            return Precio * Cantidad;
        }

        public virtual string ObtenerDetalle()
        {
            return $"({Cantidad}) {Nombre} -> Subtotal: S/{CalcularSubtotal():F2}";
        }
    }
}