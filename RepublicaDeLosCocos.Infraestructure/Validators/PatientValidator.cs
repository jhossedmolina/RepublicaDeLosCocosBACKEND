using FluentValidation;
using RepublicaDeLosCocos.Core.DTOs;

namespace RepublicaDeLosCocos.Infraestructure.Validators
{
    public class PatientValidator : AbstractValidator<PatientDTO>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient.IdentificationNumber)
                .NotNull(); 

            RuleFor(patient => patient.IdTriage)
                .NotNull();

            RuleFor(patient => patient.FullName)
                .NotNull()
                .Length(10, 30);

            RuleFor(patient => patient.Age)
                .NotNull();

            RuleFor(patient => patient.Gender)
                .NotNull()
                .Length(7, 15);

            RuleFor(patient => patient.Symptom)
                .NotNull()
                .Length(10, 500);

            /*RuleFor(patient => patient.CheckIn)
                .Equal(DateTime.Now);*/
        }
    }
}
