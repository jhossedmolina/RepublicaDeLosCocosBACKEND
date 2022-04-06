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
            AssignPatient assignPatient = new AssignPatient();
            var surgery = _context.Surgery;
            if (surgery.Select(x => x.Id).Contains(id) && surgery.Select(x => x.IdSurgeryStatus).Contains(1))
            {
                Patient patient = new Patient();
                var querySurgery = _context.Surgery
                                    .Where(q => q.Id.Equals(id))
                                    .Where(i => i.IdSurgeryStatus.Equals(1));
                var surgeryAssigned = querySurgery.FirstOrDefault();
                surgeryAssigned.IdSurgeryStatus = 2;
                _context.Surgery.Update(surgeryAssigned);

                var queryPatient = _context.Patient
                                 .Where(ps => ps.IdPatientStatus.Equals(1))
                                 .OrderBy(t => t.IdTriage)
                                 .ThenBy(t => t.CheckIn);
                patient = queryPatient.FirstOrDefault();
                patient.IdPatientStatus = 2;
                _context.Patient.Update(patient);

                assignPatient.IdSurgery = surgeryAssigned.Id;
                assignPatient.IdPatient = patient.Id;
                assignPatient.IdTriage = patient.IdTriage;
                assignPatient.IdPatientStatus = 2;
                assignPatient.RegistrationDate = DateTime.Now;
                _context.AssignPatient.Add(assignPatient);
                await _context.SaveChangesAsync();
            }
            return assignPatient;
        }
    }
}
