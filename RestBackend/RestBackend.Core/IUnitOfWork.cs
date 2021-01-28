using System;
using System.Threading.Tasks;
using RestBackend.Core.Repositories;

namespace RestBackend.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductoRepository Productos { get; }

        IClienteRepository Clientes { get; }

        IFacturaRepository Facturas { get; }

        Task<int> CommitAsync();
    }
}