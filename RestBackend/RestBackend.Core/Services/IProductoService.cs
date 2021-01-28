using RestBackend.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Core.Services
{
    public interface IProductoService
    {
        Task<Producto> GetById(int Id);

        Task<IEnumerable<Producto>> GetAll();

        Task<Producto> Create(Producto newItem);

        Task Update(Producto newItem, Producto source);
    }
}
