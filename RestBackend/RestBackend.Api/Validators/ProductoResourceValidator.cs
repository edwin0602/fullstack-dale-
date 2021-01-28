using FluentValidation;
using RestBackend.Api.Resources;

namespace RestBackend.Api.Validators
{
    public class ProductoResourceValidator : AbstractValidator<NuevoProductoResource>
    {
        public ProductoResourceValidator()
        {
            RuleFor(a => a.Nombre)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(a => a.ValorUnitario)
                .NotNull();
        }
    }

}
