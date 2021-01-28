using System.Collections.Generic;

namespace RestBackend.Core.Models
{
    public class FacturaDetalle
    {
        public Producto Producto { get; set; }

        public int ProductoId { get; set; }

        public Factura Factura { get; set; }

        public int FacturaId { get; set; }

        public int Cantidad { get; set; } = 0;

        public decimal ValorUnitario { get; set; } = 0;

        public decimal ValorTotal { get => (Producto?.ValorUnitario * Cantidad) ?? 0; }
    }
}
