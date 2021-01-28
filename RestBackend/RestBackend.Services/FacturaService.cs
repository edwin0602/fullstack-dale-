using RestBackend.Core;
using RestBackend.Core.Models;
using RestBackend.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBackend.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacturaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Factura> Create(Factura newItem)
        {
            newItem.Numero = Guid.NewGuid().ToString("D");
            newItem.Registro = DateTime.Now;

            await _unitOfWork.Facturas.AddAsync(newItem);
            await _unitOfWork.CommitAsync();

            return newItem;
        }

        public async Task Update(Factura newItem, Factura source)
        {
            source.SetForUpdate(newItem);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Factura>> GetAll()
            => await _unitOfWork.Facturas
                .GetAllAsync();

        public async Task<Factura> GetById(int Id)
            => await _unitOfWork.Facturas
                .GetByIdCompleteAsync(Id);

    }
}
