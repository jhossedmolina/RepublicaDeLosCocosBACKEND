using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class RecoveredPatientService : IRecoveredPatientService
    {
        private readonly IRecoveredPatientRepository _recoveredPatientRepository;

        public RecoveredPatientService(IRecoveredPatientRepository recoveredPatientRepository)
        {
            _recoveredPatientRepository = recoveredPatientRepository;
        }

        public async Task<IEnumerable<Patient>> GetRecoveredPatients()
        {
            return await _recoveredPatientRepository.GetRecoveredPatients();
        }
    }
}
