using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IMedicalConsultationService
    {
        Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic);
    }
}
