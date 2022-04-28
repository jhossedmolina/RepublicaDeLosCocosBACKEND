using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
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

        public async Task<PatientForCare> GetPatient(int id)
        {
            var assignedPatient = await _context.AssignPatient.FirstOrDefaultAsync(x => x.Id == id);
            return (PatientForCare)assignedPatient;
        }

        public async Task InsertAssignedPatient(AssignPatient assignPatient)
        {
            _context.AssignPatient.Add(assignPatient);
            await _context.SaveChangesAsync();
        }

        public AssignPatient CurrentSurgery(int id)
        {
            var querySurgery = _context.AssignPatient.Where(x => x.IdPatient == id).OrderByDescending(r => r.RegistrationDate);
            var surgery = querySurgery.FirstOrDefault();
            
            return surgery;
        }
    }
}
