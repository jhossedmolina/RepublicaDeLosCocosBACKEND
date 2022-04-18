using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class MedicalConsultationService : IMedicalConsultationService
    {
        private readonly IMedicalConsultationRepository _medicalConsultationRepository;
        private readonly IPatientRepository _patientRepository;

        public MedicalConsultationService(IPatientRepository patientRepository, IMedicalConsultationRepository medicalConsultationRepository)
        {
            _patientRepository = patientRepository;
            _medicalConsultationRepository = medicalConsultationRepository;
        }

        public async Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic)
        {
            var currentPatient = await _patientRepository.GetPatient(id);
            if (currentPatient.IdPatientStatus != 2)
            {
                throw new Exception($"El Paciente {currentPatient.Id} {currentPatient.FullName} No Ha Sido Atendido Por Ningun Doctor, Por Lo Tanto No Puede Cambiar El Triage");
            }
               
            return await _medicalConsultationRepository.UpdatePatientDiagnostic(id, patientDiagnostic);
        }
    }
}
