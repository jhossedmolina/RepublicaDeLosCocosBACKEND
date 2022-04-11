using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IPatientInCareRepository
    {
        Task<IEnumerable<PatientInCare>> GetPatientsAssigned();
    }
}
