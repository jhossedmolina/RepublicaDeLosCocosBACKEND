using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task InsertPatient(Patient patient);
        Patient FirstPatient();
    }
}
