using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class SurgeryStatusService : ISurgeryStatusService
    {
        private readonly ISurgeryStatusRepository _surgeryStatusRepository;

        public SurgeryStatusService(ISurgeryStatusRepository surgeryStatusRepository)
        {
            _surgeryStatusRepository = surgeryStatusRepository;
        }

        public async Task<IEnumerable<SurgeryStatus>> GetSurgerysStatus()
        {
            return await _surgeryStatusRepository.GetSurgerysStatus();
        }

        public async Task InsertSurgeryStatus(SurgeryStatus surgeryStatus)
        {
            await _surgeryStatusRepository.InsertSurgeryStatus(surgeryStatus);
        }
    }
}
