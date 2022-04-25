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

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
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
    }
}
