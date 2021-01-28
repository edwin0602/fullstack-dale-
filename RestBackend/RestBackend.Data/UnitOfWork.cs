using System.Threading.Tasks;
using RestBackend.Core;
using RestBackend.Core.Repositories;
using RestBackend.Data.Repositories;

namespace RestBackend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestBackendDbContext _context;

        private ProductoRepository _ProductosRepository;
        private ClienteRepository _ClienteRepository;
        private FacturaRepository _FacturasRepository;

        public UnitOfWork(RestBackendDbContext context)
        {
            this._context = context;
        }

        public IProductoRepository Productos => _ProductosRepository ??= new ProductoRepository(_context);

        public IClienteRepository Clientes => _ClienteRepository ??= new ClienteRepository(_context);

        public IFacturaRepository Facturas => _FacturasRepository ??= new FacturaRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}