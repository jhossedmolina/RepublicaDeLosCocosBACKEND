using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class RecoveredPatientRepository : IRecoveredPatientRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public RecoveredPatientRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetRecoveredPatients()
        {
            var recoveredPatients = await _context.Patient
            .Where(ps => ps.IdPatientStatus.Equals(3))
            .OrderBy(t => t.IdTriage)
            .ThenBy(t => t.CheckIn)
            .ToListAsync();
            return recoveredPatients;
        }
    }
}
