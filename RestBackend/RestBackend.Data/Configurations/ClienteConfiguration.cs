using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestBackend.Core.Models;

namespace RestBackend.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                 .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
              .Property(m => m.Cedula)
              .IsRequired();

            builder
              .Property(m => m.Nombre)
              .IsRequired();

            builder
              .Property(m => m.Apellido)
              .IsRequired();

            builder
                .ToTable("Cliente");
        }
    }
}
