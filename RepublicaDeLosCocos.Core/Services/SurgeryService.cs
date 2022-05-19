using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class SurgeryService : ISurgeryService
    {
        private readonly ISurgeryRepository _surgeryRepository;

        public SurgeryService(ISurgeryRepository surgeryRepository)
        {
            _surgeryRepository = surgeryRepository;
        }

        public async Task<IEnumerable<Surgery>> GetSurgerys()
        {
            return await _surgeryRepository.GetSurgerys();
        }

        public async Task<IEnumerable<Surgery>> GetSurgerysInCare()
        {
            return await _surgeryRepository.GetSurgerysInCare();
        }

        public async Task<Surgery> GetSurgery(int id)
        {
            return await _surgeryRepository.GetSurgery(id);
        }

        public async Task InsertSurgery(Surgery surgery)
        {
            await _surgeryRepository.InsertSurgery(surgery);
        }

        public async Task<bool> DeleteSurgery(int id)
        {
            return await _surgeryRepository.DeleteSurgery(id);
        }
    }
}
