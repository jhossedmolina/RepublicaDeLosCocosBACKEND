using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Exceptions;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class MedicalConsultationService : IMedicalConsultationService
    {
        private readonly IMedicalConsultationRepository _medicalConsultationRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAssignPatientRepository _assignPatientRepository;
        private readonly ISurgeryRepository _surgeryRepository;

        public MedicalConsultationService(IPatientRepository patientRepository, IMedicalConsultationRepository medicalConsultationRepository, IAssignPatientRepository assignPatientRepository,
            ISurgeryRepository surgeryRepository)
        {
            _patientRepository = patientRepository;
            _medicalConsultationRepository = medicalConsultationRepository;
            _assignPatientRepository = assignPatientRepository;
            _surgeryRepository = surgeryRepository;
        }

        public async Task<bool> RecoveredPatient(int id)
        {
            var currentPatient = await _patientRepository.GetPatient(id);
            var currentData = _assignPatientRepository.CurrentSurgery(id);
            var surgery = await _surgeryRepository.GetSurgery(currentData.IdSurgery);
            if (currentPatient.IdPatientStatus != 2)
            {
                throw new BusinessException($"El Paciente {currentPatient.Id} - {currentPatient.FullName} No Ha Sido Atendido Por Ningun Doctor, Por Lo Tanto No Puede Darle De Alta");
            }
            else if (currentData.Diagnostic == null)
            {
                throw new BusinessException($"No Se Ha Ingresado El Diagnostico Para el Paciente {currentPatient.Id} {currentPatient.FullName}");
            }
            else
            {
                currentPatient.IdPatientStatus = 3;
                surgery.IdSurgeryStatus = 1;
            }
            return await _medicalConsultationRepository.RecoveredPatient(id);
        }

        public async Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic)
        {
            var currentPatient = await _patientRepository.GetPatient(id);
            if (currentPatient.IdPatientStatus != 2)
            {
                throw new BusinessException($"El Paciente {currentPatient.Id} - {currentPatient.FullName} No Ha Sido Atendido Por Ningun Doctor, Por Lo Tanto No Puede Ingresar El Diagnostico");
            }
               
            return await _medicalConsultationRepository.UpdatePatientDiagnostic(id, patientDiagnostic);
        }

        public async Task<bool> UpdatePatientTriage(int id, UnrecoveredPatient patient)
        {
            var currentPatient = await _patientRepository.GetPatient(id);
            var currentSurgery = _assignPatientRepository.CurrentSurgery(id).IdSurgery;
            var surgery = await _surgeryRepository.GetSurgery(currentSurgery);

            if (currentPatient.IdPatientStatus != 2)
            {
                throw new BusinessException($"El Paciente {currentPatient.Id} {currentPatient.FullName} No Ha Sido Atendido Por Ningun Doctor, Por Lo Tanto No Puede Cambiar El Triage");
            }
            else
            {
                surgery.IdSurgeryStatus = 1;
            }

            return await _medicalConsultationRepository.UpdatePatientTriage(id, patient);
        }
    }
}
