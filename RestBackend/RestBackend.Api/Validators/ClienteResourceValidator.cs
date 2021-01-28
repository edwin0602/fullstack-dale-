using FluentValidation;
using RestBackend.Api.Resources;

namespace RestBackend.Api.Validators
{
    public class ClienteResourceValidator : AbstractValidator<NuevoClienteResource>
    {
        public ClienteResourceValidator()
        {

            RuleFor(a => a.Nombre)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(a => a.Apellido)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(a => a.Cedula)
                .NotEmpty()
                .MinimumLength(7);

            RuleFor(a => a.Telefono)
                .NotEmpty()
                .MinimumLength(7);
        }
    }

}
