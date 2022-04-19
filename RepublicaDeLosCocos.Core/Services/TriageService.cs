using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class TriageService : ITriageService
    {
        private readonly ITriageRepository _triageRepository;
        public TriageService(ITriageRepository triageRepository)
        {
            _triageRepository = triageRepository;
        }

        public async Task<IEnumerable<Triage>> GetTriages()
        {
            return await _triageRepository.GetTriages();
        }

        public async Task InsertTriage(Triage triage)
        {
            await _triageRepository.InsertTriage(triage);
        }
    }
}
