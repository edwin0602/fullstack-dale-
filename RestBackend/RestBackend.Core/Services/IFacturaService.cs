using RestBackend.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Core.Services
{
    public interface IFacturaService
    {
        Task<Factura> GetById(int Id);

        Task<IEnumerable<Factura>> GetAll();

        Task<Factura> Create(Factura newItem);

        Task Update(Factura newItem, Factura source);
    }
}
