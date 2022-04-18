using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class RecoveredPatientService : IRecoveredPatientService
    {
        private readonly IRecoveredPatientRepository _recoveredPatientRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAssignPatientRepository _assignPatientRepository;
        private readonly ISurgeryRepository _surgeryRepository;

        public RecoveredPatientService(IRecoveredPatientRepository recoveredPatientRepository,IPatientRepository patientRepository,IAssignPatientRepository assignPatientRepository, 
            ISurgeryRepository surgeryRepository)
        {
            _recoveredPatientRepository = recoveredPatientRepository;
            _patientRepository = patientRepository;
            _assignPatientRepository = assignPatientRepository;
            _surgeryRepository = surgeryRepository;
        }

        public async Task<IEnumerable<Patient>> GetRecoveredPatients()
        {
            return await _recoveredPatientRepository.GetRecoveredPatients();
        }

        public async Task<bool> RecoveredPatient(int id)
        {
            var currentPatient = await _patientRepository.GetPatient(id);
            var currentData = _assignPatientRepository.CurrentSurgery(id);
            var surgery = await _surgeryRepository.GetSurgery(currentData.IdSurgery);
            if (currentPatient.IdPatientStatus != 2)
            {
                throw new Exception($"El Paciente {currentPatient.Id} {currentPatient.FullName} No Ha Sido Atendido Por Ningun Doctor, Por Lo Tanto No Puede Darle De Alta");
            }
            else if(currentData.Diagnostic == null)
            {
                throw new Exception($"No Se Ha Ingresado El Diagnostico Para el Paciente {currentPatient.Id} {currentPatient.FullName}");
            }
            else
            {
                currentPatient.IdPatientStatus = 3;
                surgery.IdSurgeryStatus = 1;
            }
            return await _recoveredPatientRepository.RecoveredPatient(id);
        }
    }
}
