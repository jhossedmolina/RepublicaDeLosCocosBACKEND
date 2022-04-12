using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface ISurgeryService
    {
        Task<bool> DeleteSurgery(int id);
        Task<Surgery> GetSurgery(int id);
        Task<IEnumerable<Surgery>> GetSurgerys();
        Task InsertSurgery(Surgery surgery);
    }
}