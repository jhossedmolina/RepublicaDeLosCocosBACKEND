using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class SurgeryStatusRepository : ISurgeryStatusRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public SurgeryStatusRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SurgeryStatus>> GetSurgerysStatus()
        {
            var surgerysStatus = await _context.SurgeryStatus.ToListAsync();
            return surgerysStatus;
        }

        public async Task InsertSurgeryStatus(SurgeryStatus surgeryStatus)
        {
            _context.SurgeryStatus.Add(surgeryStatus);
            await _context.SaveChangesAsync();
        }
    }
}
