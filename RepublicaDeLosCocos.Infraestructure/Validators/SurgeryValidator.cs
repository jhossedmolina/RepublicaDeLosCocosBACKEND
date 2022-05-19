using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class SurgeryValidator : AbstractValidator<SurgeryDTO>
    {
        public SurgeryValidator()
        {
            RuleFor(surgery => surgery.Id)
                .NotNull();

            RuleFor(surgery => surgery.SurgeryName)
                .NotNull()
                .Length(8, 100);

            RuleFor(surgery => surgery.NameDoctor)
                .NotNull()
                .Length(8, 50);
        }
    }
}
