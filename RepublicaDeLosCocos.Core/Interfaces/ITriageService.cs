using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface ITriageService
    {
        Task<IEnumerable<Triage>> GetTriages();
        Task InsertTriage(Triage triage);
    }
}
