using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class PatientInCareService : IPatientInCareService
    {
        private readonly IPatientInCareRepository _patientInCareRepository;

        public PatientInCareService(IPatientInCareRepository patientInCareRepository)
        {
            _patientInCareRepository = patientInCareRepository;
        }

        public async Task<IEnumerable<PatientInCare>> GetPatientsAssigned()
        {
            return await _patientInCareRepository.GetPatientsAssigned();
        }
    }
}
