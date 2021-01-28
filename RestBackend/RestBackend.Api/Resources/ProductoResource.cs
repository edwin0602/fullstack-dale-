namespace RestBackend.Api.Resources
{
    public class ProductoResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal ValorUnitario { get; set; }
    }

    public class NuevoProductoResource
    {
        public string Nombre { get; set; }

        public decimal ValorUnitario { get; set; }
    }
}
