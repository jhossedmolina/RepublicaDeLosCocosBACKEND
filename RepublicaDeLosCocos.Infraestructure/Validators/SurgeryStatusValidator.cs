using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class SurgeryStatusValidator : AbstractValidator<SurgeryStatusDTO>
    {
        public SurgeryStatusValidator()
        {
            RuleFor(surgeryStatus => surgeryStatus.Id)
                .NotNull();

            RuleFor(surgeryStatus => surgeryStatus.StatusName)
                .NotNull()
                .Length(4, 10);
        }
    }
}
