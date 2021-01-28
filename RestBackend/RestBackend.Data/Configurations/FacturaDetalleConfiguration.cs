using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBackend.Core.Models;

namespace RestBackend.Data.Configurations
{
    public class FacturaDetalleConfiguration : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder
                .HasKey(m => new { m.FacturaId, m.ProductoId });

            builder
                .Property(m => m.Cantidad)
                .IsRequired();

            builder
                .Property(m => m.ValorUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
              .HasOne(m => m.Producto)
              .WithMany(m => m.FacturaDetalles);

            builder
                .HasOne(m => m.Factura)
                .WithMany(m => m.Detalles);

            builder
                .Ignore(m => m.ValorTotal);

            builder
                .ToTable("FacturaDetalle");
        }
    }
}
