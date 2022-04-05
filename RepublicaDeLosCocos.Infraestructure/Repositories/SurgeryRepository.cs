using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class SurgeryRepository : ISurgeryRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context; 

        public SurgeryRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Surgery>> GetSurgerys()
        {
            var surgerys = await _context.Surgery.ToListAsync();
            return surgerys;
        }

        public async Task InsertSurgery(Surgery surgery)
        {
            _context.Surgery.Add(surgery);
            await _context.SaveChangesAsync();
        }
    }
}
