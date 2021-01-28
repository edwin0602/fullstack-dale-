using RestBackend.Core;
using RestBackend.Core.Models;
using RestBackend.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBackend.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Create(Cliente newItem)
        {
            await _unitOfWork.Clientes.AddAsync(newItem);
            await _unitOfWork.CommitAsync();

            return newItem;
        }

        public async Task Update(Cliente newItem, Cliente source)
        {
            source.SetForUpdate(newItem);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
            => await _unitOfWork.Clientes
                .GetAllAsync(q => q.OrderBy(s => s.Nombre));

        public async Task<Cliente> GetById(int Id)
            => await _unitOfWork.Clientes
                .FirstOrDefaultAsync(w => w.Id == Id);

        public async Task<Cliente> GetByCedula(string Cedula)
            => await _unitOfWork.Clientes
                .FirstOrDefaultAsync(w => w.Cedula == Cedula);
    }
}
