using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class TriageValidator : AbstractValidator<TriageDTO>
    {
        public TriageValidator()
        {
            RuleFor(triage => triage.Id)
                .NotNull();

            RuleFor(triage => triage.TriageName)
                .NotNull()
                .Length(6, 20);
        }
    }
}
