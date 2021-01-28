using System.Collections.Generic;

namespace RestBackend.Core.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal ValorUnitario { get; set; }

        public List<FacturaDetalle> FacturaDetalles { get; set; }

        public void SetForUpdate(Producto source)
        {
            Nombre = source.Nombre;
            ValorUnitario = source.ValorUnitario;
        }
    }
}
