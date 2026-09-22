using System;

namespace ConsoleApp_07_09_2026.Clases
{
    public abstract class Producto : IProducto
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

        protected Producto(string nombre, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public virtual decimal CalcularSubtotal()
        {
            return Precio * Cantidad;
        }

        // Obliga a las clases hijas a definir cómo mostrar su propio detalle
        public abstract string ObtenerDetalle();
    }
}