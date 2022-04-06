using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class TreatedRepository : ITreatedRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;

        public TreatedRepository(RepublicaDeLosCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Treated>> GetPatientsAssigned()
        {
            var queryTreated = await _context.AssignPatient
                .Join(_context.Surgery, asg => asg.IdSurgery, s => s.Id, (asg, s) => new { asg, s })
                .Join(_context.Patient, asp => asp.asg.IdPatient, p => p.Id, (asp, p) => new { asp, p })
                .Select(m => new Treated
                {
                    IdSurgery = m.asp.asg.IdSurgery,
                    SurgeryName = m.asp.s.SurgeryName,
                    NameDoctor = m.asp.s.NameDoctor,
                    IdPatient = m.asp.asg.IdPatient,
                    FullName = m.p.FullName,
                    Age = m.p.Age,
                    Gender = m.p.Gender,
                    IdTriage = m.asp.asg.IdTriage,
                    Symptom = m.p.Symptom,
                    IdPatientStatus = m.asp.asg.IdPatientStatus,
                }).ToListAsync();
            return queryTreated;
        }
    }
}
