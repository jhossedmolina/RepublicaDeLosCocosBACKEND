using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface ISurgeryStatusService
    {
        Task<IEnumerable<SurgeryStatus>> GetSurgerysStatus();
        Task InsertSurgeryStatus(SurgeryStatus surgeryStatus);
    }
}
