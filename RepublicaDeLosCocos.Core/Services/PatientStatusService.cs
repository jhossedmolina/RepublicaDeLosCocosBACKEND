using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class PatientStatusService : IPatientStatusService
    {
        private readonly IPatientStatusRepository _patientStatusRepository;

        public PatientStatusService(IPatientStatusRepository patientStatusRepository)
        {
            _patientStatusRepository = patientStatusRepository;
        }

        public async Task<IEnumerable<PatientStatus>> GetPatientsStatus()
        {
            return await _patientStatusRepository.GetPatientsStatus();
        }

        public async Task InsertPatientStatus(PatientStatus patientStatus)
        {
            await _patientStatusRepository.InsertPatientStatus(patientStatus);
        }
    }
}
