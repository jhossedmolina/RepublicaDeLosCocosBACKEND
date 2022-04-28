using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IAssignPatientRepository
    {
        Task<PatientForCare> GetPatient(int id);
        Task InsertAssignedPatient(AssignPatient assignPatient);
        AssignPatient CurrentSurgery(int id);
    }
}
