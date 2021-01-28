using RestBackend.Core.Models;
using RestBackend.Core.Repositories;

namespace RestBackend.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(RestBackendDbContext context)
            : base(context)
        { }
    }
}
