using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        Queue patientQueue = new Queue();
        public PatientRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context; 
        }
        
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            int patientStatus = 1;
            var patients = await _context.Patient
                    .Where(ps => ps.IdPatientStatus.Equals(patientStatus))
                    .OrderBy(t => t.IdTriage)
                    .ThenBy(t => t.CheckIn)
                    .ToListAsync();
            patientQueue.Enqueue(patients);
            return patients;
        }




    }
}
