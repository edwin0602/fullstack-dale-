using FluentValidation;
using RestBackend.Api.Resources;

namespace RestBackend.Api.Validators
{
    public class FacturaResourceValidator : AbstractValidator<NuevoFacturaResource>
    {
        public FacturaResourceValidator()
        {
            RuleFor(a => a.ClienteId)
                .NotNull();
        }
    }

}
