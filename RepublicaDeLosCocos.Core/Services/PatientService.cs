using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAssignPatientRepository _assignPatientRepository;
        private readonly ISurgeryRepository _surgeryRepository;
        public PatientService(IPatientRepository patientRepository,IAssignPatientRepository assignPatientRepository,ISurgeryRepository surgeryRepository)
        {
            _patientRepository = patientRepository;
            _assignPatientRepository = assignPatientRepository;
            _surgeryRepository = surgeryRepository;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task InsertPatient(Patient patient)
        {
            patient.IdPatientStatus = 1;
            if (patient.CheckIn == null) patient.CheckIn = DateTime.Now;
            await _patientRepository.InsertPatient(patient);
        }

        public async Task<bool> UpdatePatientTriage(int id, UnrecoveredPatient patient)
        {
            var currentPatient = await _patientRepository.GetPatient(id);
            var currentSurgery = _assignPatientRepository.CurrentSurgery(id).IdSurgery;
            var surgery = await _surgeryRepository.GetSurgery(currentSurgery);
            
            if (currentPatient.IdPatientStatus != 2)
            {
                throw new Exception($"El Paciente {currentPatient.Id} {currentPatient.FullName} No Ha Sido Atendido Por Ningun Doctor, Por Lo Tanto No Puede Cambiar El Triage");
            }
            else
            {
                surgery.IdSurgeryStatus = 1;
            }  

            return await _patientRepository.UpdatePatientTriage(id, patient);
        }
    }
}
