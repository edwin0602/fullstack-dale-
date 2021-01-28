using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBackend.Core.Models;

namespace RestBackend.Data.Configurations
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder
                 .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Numero)
                .IsRequired();

            builder
                .HasOne(m => m.Cliente)
                .WithMany(m => m.Facturas);

            builder
                .ToTable("Factura");
        }
    }
}
