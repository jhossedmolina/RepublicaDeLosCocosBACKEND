using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface ISurgeryRepository
    {
        Task<IEnumerable<Surgery>> GetSurgerys();
        Task<IEnumerable<Surgery>> GetSurgerysInCare();
        Task<Surgery> GetSurgery(int id);
        Task InsertSurgery(Surgery surgery);
        Task<bool> DeleteSurgery(int id);
    }
}
