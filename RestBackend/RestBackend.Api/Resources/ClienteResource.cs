namespace RestBackend.Api.Resources
{
    public class ClienteResource
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string NombreCompleto { get => $"{Nombre} {Apellido}"; }
    }

    public class NuevoClienteResource
    {
        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }
    }
}
