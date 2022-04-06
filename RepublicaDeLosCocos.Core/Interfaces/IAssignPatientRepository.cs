using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IAssignPatientRepository
    {
        Task<AssignPatient> GetPatient(int id);
    }
}
