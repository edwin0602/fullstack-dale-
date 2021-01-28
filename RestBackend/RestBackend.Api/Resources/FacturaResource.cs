using System;
using System.Collections.Generic;
using System.Linq;

namespace RestBackend.Api.Resources
{
    public class FacturaResource
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public DateTime Registro { get; set; }

        public List<FacturaDetalleResource> Detalles { get; set; }

        public ClienteResource Cliente { get; set; }

        public decimal Total { get => Detalles?.Select(x => x.ValorTotal).Sum() ?? 0; }
    }

    public class FacturaDetalleResource
    {
        public string ProductoId { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get => (Cantidad * ValorUnitario); }
    }

    public class NuevoFacturaResource
    {
        public int ClienteId { get; set; }

        public List<NuevoFacturaDetalleResource> Detalles { get; set; }
    }

    public class NuevoFacturaDetalleResource
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
    }

}
