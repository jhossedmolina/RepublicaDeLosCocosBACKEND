using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
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
            var patients = await _context.Triage.ToListAsync();
            return patients;
        }

        public async Task InsertTriage(Triage triage)
        {
            _context.Triage.Add(triage);
            await _context.SaveChangesAsync(); 
        }
    }
}
