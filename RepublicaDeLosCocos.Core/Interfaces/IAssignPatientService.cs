using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IAssignPatientService
    {
        Task<AssignPatient> GetPatient(int id);
    }
}