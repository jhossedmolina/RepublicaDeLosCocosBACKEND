using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class TriageRepository : ITriageRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public TriageRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Triage>> GetTriages()
        {
            var triages = await _context.Triage.ToListAsync();
            return triages;
        }

        public async Task InsertTriage(Triage triage)
        {
            _context.Triage.Add(triage);
            await _context.SaveChangesAsync(); 
        }
    }
}
