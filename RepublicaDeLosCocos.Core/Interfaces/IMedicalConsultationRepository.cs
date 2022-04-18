using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IMedicalConsultationRepository
    {
        Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic);
    }
}
