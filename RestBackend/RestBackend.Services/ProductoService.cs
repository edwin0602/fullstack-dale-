using RestBackend.Core;
using RestBackend.Core.Models;
using RestBackend.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBackend.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Producto> Create(Producto newItem)
        {
            await _unitOfWork.Productos.AddAsync(newItem);
            await _unitOfWork.CommitAsync();

            return newItem;
        }

        public async Task Update(Producto newItem, Producto source)
        {
            source.SetForUpdate(newItem);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Producto>> GetAll()
            => await _unitOfWork.Productos
                .GetAllAsync(q => q.OrderBy(s => s.Nombre));

        public async Task<Producto> GetById(int Id)
            => await _unitOfWork.Productos
                .FirstOrDefaultAsync(w => w.Id == Id);

    }
}
