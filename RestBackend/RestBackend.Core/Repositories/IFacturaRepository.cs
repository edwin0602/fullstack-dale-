using RestBackend.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Core.Repositories
{
    public interface IFacturaRepository : IRepository<Factura>
    {
        Task<IEnumerable<Factura>> GetAllAsync();

        Task<Factura> GetByIdCompleteAsync(int id);
    }
}
