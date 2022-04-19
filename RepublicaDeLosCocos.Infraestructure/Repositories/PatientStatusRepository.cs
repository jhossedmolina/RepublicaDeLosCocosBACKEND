using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class PatientStatusRepository : IPatientStatusRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public PatientStatusRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientStatus>> GetPatientsStatus()
        {
            var patientStatus = await _context.PatientStatus.ToListAsync();
            return patientStatus;
        }

        public async Task InsertPatientStatus(PatientStatus patientStatus)
        {
            _context.PatientStatus.Add(patientStatus);
            await _context.SaveChangesAsync();
        }
    }
}
