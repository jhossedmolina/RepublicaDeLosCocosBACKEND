using RepublicaDeLosCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IPatientStatusService
    {
        Task<IEnumerable<PatientStatus>> GetPatientsStatus();
        Task InsertPatientStatus(PatientStatus patientStatus);
    }
}
