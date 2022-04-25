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

        public async Task<bool> RecoveredPatient(int id)
        {
            var currentPatient = await _context.Patient.FirstOrDefaultAsync(x => x.Id == id);
            currentPatient.IdPatientStatus = 3;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdatePatientDiagnostic(int id, PatientDiagnostic patientDiagnostic)
        {
            var assignedPatient = _context.AssignPatient.Where(x => x.IdPatient == id).OrderByDescending(r => r.RegistrationDate);
            var currentPatient = await assignedPatient.FirstOrDefaultAsync(x => x.IdPatient == id);
            currentPatient.Diagnostic = patientDiagnostic.Diagnostic;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> UpdatePatientTriage(int id, UnrecoveredPatient unrecoveredPatient)
        {
            var currentPatient = await _context.Patient.FirstOrDefaultAsync(x => x.Id == id);

            currentPatient.IdTriage = unrecoveredPatient.IdTriage;
            currentPatient.IdPatientStatus = 1;
            currentPatient.CheckIn = DateTime.Now;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }



    }
}
