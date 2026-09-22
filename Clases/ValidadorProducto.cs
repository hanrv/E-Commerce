using System;
using ConsoleApp_07_09_2026.Interfaces;

namespace ConsoleApp_07_09_2026.Clases
{
    /// <summary>
    /// Clase que valida valores para productos (precio, cantidad).
    /// PRINCIPIO SRP (Single Responsibility Principle): Esta clase solo valida valores.
    /// La responsabilidad de validación está separada de la clase Producto.
    /// </summary>
    public class ValidadorProducto : IValidador
    {
        private readonly string _nombrePropiedad;
        private readonly decimal _valorMinimo;

        public ValidadorProducto(string nombrePropiedad, decimal valorMinimo = 0)
        {
            _nombrePropiedad = nombrePropiedad;
            _valorMinimo = valorMinimo;
        }

        public bool EsValido(decimal valor)
        {
            return valor >= _valorMinimo;
        }

        public decimal ObtenerValorCorregido(decimal valor)
        {
            return EsValido(valor) ? valor : _valorMinimo;
        }

        public string ObtenerMensajeError()
        {
            return $"El {_nombrePropiedad} no puede ser negativo. Se asignará {_valorMinimo}.";
        }
    }
}
