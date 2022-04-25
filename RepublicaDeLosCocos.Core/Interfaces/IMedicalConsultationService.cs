using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IMedicalConsultationService
    {
        Task<bool> RecoveredPatient(int id);
        Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic);
        Task<bool> UpdatePatientTriage(int id, UnrecoveredPatient patient);
    }
}
