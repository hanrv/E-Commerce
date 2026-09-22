using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Clase que representa un producto genérico.
    /// PRINCIPIO SRP (Single Responsibility Principle): Producto solo gestiona los datos del producto.
    /// La validación está delegada a IValidador (inyectado en las propiedades).
    /// PRINCIPIO LSP (Liskov Substitution Principle): Subclases pueden reemplazar esta clase
    /// sin romper el contrato (ObtenerDetalle es virtual para permitir extensión).
    /// </summary>
    public class Producto
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private decimal _precio;
        private readonly IValidador _validadorPrecio;

        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (!_validadorPrecio.EsValido(value))
                {
                    _precio = _validadorPrecio.ObtenerValorCorregido(value);
                }
                else
                {
                    _precio = value;
                }
            }
        }

        private int _cantidad;
        private readonly IValidador _validadorCantidad;

        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (!_validadorCantidad.EsValido(value))
                {
                    _cantidad = (int)_validadorCantidad.ObtenerValorCorregido(value);
                }
                else
                {
                    _cantidad = value;
                }
            }
        }

        public Producto(string nombre, decimal precio, int cantidad)
        {
            // PRINCIPIO SRP: Los validadores son inyectados/creados, separando la lógica de validación
            _validadorPrecio = new ValidadorProducto("precio", 0);
            _validadorCantidad = new ValidadorProducto("cantidad", 0);

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
