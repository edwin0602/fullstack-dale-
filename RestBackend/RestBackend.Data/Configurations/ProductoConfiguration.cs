using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBackend.Core.Models;

namespace RestBackend.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder
                 .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
              .Property(m => m.Nombre)
              .IsRequired();

            builder
             .Property(m => m.ValorUnitario)
             .HasColumnType("decimal(18,2)")
             .IsRequired();

            builder
                .ToTable("Producto");
        }
    }
}
