namespace ConsoleApp_07_09_2026.Clases
{
    public class Comida : Producto
    {
        public bool EsCaliente { get; set; }

        public Comida(string nombre, decimal precio, int cantidad, bool esCaliente)
            : base(nombre, precio, cantidad)
        {
            EsCaliente = esCaliente;
        }

        public override string ObtenerDetalle()
        {
            string estado = EsCaliente ? "Caliente" : "Frío";
            return $"[Comida] ({Cantidad}) {Nombre} [{estado}] -> Subtotal: S/{CalcularSubtotal():F2}";
        }
    }
}