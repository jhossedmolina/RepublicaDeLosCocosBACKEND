using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class UnrecoveredPatientValidator : AbstractValidator<UnrecoveredPatientDTO>
    {
        public UnrecoveredPatientValidator()
        {
            RuleFor(unrecovered => unrecovered.IdTriage)
                .NotNull();
        }
    }
}
