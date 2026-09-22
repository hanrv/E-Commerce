namespace ConsoleApp_07_09_2026.Clases
{
    public class Bebida : Producto
    {
        public int Mililitros { get; set; }

        public Bebida(string nombre, decimal precio, int cantidad, int mililitros)
            : base(nombre, precio, cantidad)
        {
            Mililitros = mililitros;
        }

        public override string ObtenerDetalle()
        {
            return $"[Bebida] ({Cantidad}) {Nombre} ({Mililitros} ml) -> Subtotal: S/{CalcularSubtotal():F2}";
        }
    }
}