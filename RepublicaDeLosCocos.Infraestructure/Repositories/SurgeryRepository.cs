using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Surgery>> GetSurgerysInCare()
        {
            var surgerysInCare = await _context.Surgery.Where(x => x.IdSurgeryStatus == 2).ToListAsync();
            return surgerysInCare;
        }

        public async Task<Surgery> GetSurgery(int id)
        {
            var surgery = await _context.Surgery.FirstOrDefaultAsync(x => x.Id == id);
            return surgery;
        }

        public async Task InsertSurgery(Surgery surgery)
        {
            surgery.IdSurgeryStatus = 1;
            _context.Surgery.Add(surgery);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteSurgery(int id)
        {
            var currentSurgery = await GetSurgery(id);
            _context.Surgery.RemoveRange(currentSurgery);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
