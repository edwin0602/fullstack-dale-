using RestBackend.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Core.Services
{
    public interface IClienteService
    {
        Task<Cliente> GetById(int Id);

        Task<Cliente> GetByCedula(string Cedula);

        Task<IEnumerable<Cliente>> GetAll();

        Task<Cliente> Create(Cliente newItem);

        Task Update(Cliente newItem, Cliente source);
    }
}
