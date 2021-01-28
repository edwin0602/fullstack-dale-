using System.Collections.Generic;

namespace RestBackend.Core.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public List<Factura> Facturas { get; set; }

        public void SetForUpdate(Cliente source)
        {
            Nombre = source.Nombre;
            Apellido = source.Apellido;
            Telefono = source.Telefono;
        }
    }
}
