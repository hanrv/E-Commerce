namespace ConsoleApp_07_09_2026.Clases
{
    public class Snack : Producto
    {
        public int Gramos { get; set; }

        public Snack(string nombre, decimal precio, int cantidad, int gramos)
            : base(nombre, precio, cantidad)
        {
            Gramos = gramos;
        }

        public override string ObtenerDetalle()
        {
            return $"[Snack]  ({Cantidad}) {Nombre} ({Gramos} g) -> Subtotal: S/{CalcularSubtotal():F2}";
        }
    }
}