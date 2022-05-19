using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class PatientDiagnosticValidator : AbstractValidator<PatientDiagnosticDTO>
    {
        public PatientDiagnosticValidator()
        {
            RuleFor(diagnostic => diagnostic.Diagnostic)
                .NotNull()
                .Length(10, 100);
        }
    }
}
