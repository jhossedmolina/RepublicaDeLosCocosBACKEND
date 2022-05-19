using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class PatientStatusValidator : AbstractValidator<PatientStatusDTO>
    {
        public PatientStatusValidator()
        {
            RuleFor(patientSatus => patientSatus.Id)
                .NotNull();

            RuleFor(patientStatus => patientStatus.StatusName)
                .NotNull()
                .Length(6, 20);
        }
    }
}
