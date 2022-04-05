using RepublicaDeLosCocos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface ISurgeryRepository
    {
        Task<IEnumerable<Surgery>> GetSurgerys();
        Task InsertSurgery(Surgery surgery);
    }
}
