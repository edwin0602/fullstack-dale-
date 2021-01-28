using AutoMapper;
using RestBackend.Api.Resources;
using RestBackend.Core.Models;

namespace RestBackend.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteResource>();
            CreateMap<ClienteResource, Cliente>();
            CreateMap<NuevoClienteResource, Cliente>();

            CreateMap<Producto, ProductoResource>();
            CreateMap<ProductoResource, Producto>();
            CreateMap<NuevoProductoResource, Producto>();

            CreateMap<FacturaResource, Factura>();
            CreateMap<Factura, FacturaResource>();
            CreateMap<NuevoFacturaResource, Factura>();

            CreateMap<FacturaDetalleResource, FacturaDetalle>();
            CreateMap<FacturaDetalle, FacturaDetalleResource>()
                .ForMember(x => x.Nombre, opt => opt.MapFrom(m => m.Producto.Nombre))
                .ForMember(x => x.ValorUnitario, opt => opt.MapFrom(m => m.Producto.ValorUnitario));

            CreateMap<NuevoFacturaDetalleResource, FacturaDetalle>();

        }
    }
}