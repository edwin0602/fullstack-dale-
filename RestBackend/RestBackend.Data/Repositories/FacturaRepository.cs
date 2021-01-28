using Microsoft.EntityFrameworkCore;
using RestBackend.Core.Models;
using RestBackend.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBackend.Data.Repositories
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(RestBackendDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await RestBackendDbContext.Facturas
                          .Include(m => m.Cliente)
                          .Include(m => m.Detalles)
                            .ThenInclude(p => p.Producto)
                          .ToListAsync();
        }

        public async Task<Factura> GetByIdCompleteAsync(int id)
        {
            return await RestBackendDbContext.Facturas
                    .Where(x => x.Id == id)
                          .Include(m => m.Cliente)
                          .Include(m => m.Detalles)
                            .ThenInclude(p => p.Producto)
                          .FirstOrDefaultAsync();
        }

        private RestBackendDbContext RestBackendDbContext
        {
            get { return Context as RestBackendDbContext; }
        }
    }
}
