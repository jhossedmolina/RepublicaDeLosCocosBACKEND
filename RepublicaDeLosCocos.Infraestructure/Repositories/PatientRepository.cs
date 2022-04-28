using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public PatientRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context; 
        }
        
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _context.Patient
                    .Where(ps => ps.IdPatientStatus.Equals(1))
                    .OrderBy(t => t.IdTriage)
                    .ThenBy(t => t.CheckIn)
                    .ToListAsync();
            return patients;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.IdentificationNumber == id);
            return patient;
        }

        public async Task InsertPatient(Patient patient)
        {
            _context.Patient.Add(patient);
            await _context.SaveChangesAsync();
        }

        public Patient FirstPatient()
        {
            var queryPatient = _context.Patient
                 .Where(ps => ps.IdPatientStatus.Equals(1))
                 .OrderBy(t => t.IdTriage)
                 .ThenBy(t => t.CheckIn);
            var patient = queryPatient.FirstOrDefault();
            return patient;
        }
    }
}
