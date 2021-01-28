using System;
using System.Collections.Generic;

namespace RestBackend.Core.Models
{
    public class Factura
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public DateTime Registro { get; set; }

        public List<FacturaDetalle> Detalles { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public void SetForUpdate(Factura source)
        {
            Detalles = source.Detalles;

            ClienteId = source.ClienteId;
            Cliente = source.Cliente;
        }
    }
}
