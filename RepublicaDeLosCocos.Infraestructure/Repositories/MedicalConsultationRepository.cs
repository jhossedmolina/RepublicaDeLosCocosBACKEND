using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class MedicalConsultationRepository : IMedicalConsultationRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public MedicalConsultationRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic)
        {
            var assignedPatient = _context.AssignPatient.Where(x => x.IdPatient == id).OrderByDescending(r => r.RegistrationDate);
            var currentPatient = await assignedPatient.FirstOrDefaultAsync(x => x.IdPatient == id);
            currentPatient.Diagnostic = patientDiagnostic.Diagnostic;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }



    }
}
