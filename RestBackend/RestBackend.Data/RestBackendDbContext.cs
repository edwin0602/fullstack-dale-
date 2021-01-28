using Microsoft.EntityFrameworkCore;
using RestBackend.Core.Models;
using RestBackend.Data.Configurations;
using System.Threading.Tasks;

namespace RestBackend.Data
{
    public class RestBackendDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }

        public RestBackendDbContext(DbContextOptions<RestBackendDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new ProductoConfiguration())
                .ApplyConfiguration(new ClienteConfiguration())
                .ApplyConfiguration(new FacturaConfiguration())
                .ApplyConfiguration(new FacturaDetalleConfiguration());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
