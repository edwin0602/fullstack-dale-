using RestBackend.Core.Models;
using RestBackend.Core.Repositories;

namespace RestBackend.Data.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(RestBackendDbContext context)
            : base(context)
        { }
    }
}
