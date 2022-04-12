using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class AssignPatientRepository : IAssignPatientRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;
        public AssignPatientRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<AssignPatient> GetPatient(int id)
        {
            var assignedPatient = await _context.AssignPatient.FirstOrDefaultAsync(x => x.Id == id);
            return assignedPatient;
        }

        public async Task InsertAssignedPatient(AssignPatient assignPatient)
        {
            _context.AssignPatient.Add(assignPatient);
            await _context.SaveChangesAsync();
        }
    }
}
