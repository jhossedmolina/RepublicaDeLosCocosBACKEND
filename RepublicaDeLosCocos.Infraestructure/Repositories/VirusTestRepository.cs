using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Infraestructure.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Infraestructure.Repositories
{
    public class VirusTestRepository : IVirusTestRepository
    {
        private readonly RepublicaDeLosCocosDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public VirusTestRepository(RepublicaDeLosCocosDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<bool> InsertTestFile([FromForm] VirusTestFileDTO testFile, int id)
        {
           
            var assignedPatient = _context.AssignPatient.Where(x => x.IdPatient == id).OrderByDescending(r => r.RegistrationDate);
            var currentPatient = await assignedPatient.FirstOrDefaultAsync(x => x.IdPatient == id);
            var rootPath = Path.Combine(_environment.ContentRootPath, "Resources", "Documents");
            

            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);

                var filePath = Path.Combine(rootPath, testFile.TestFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    currentPatient.VirusTestFile = testFile.TestFile.FileName;

                    await  testFile.TestFile.CopyToAsync(stream);

                    //await _context.SaveChangesAsync();
                }

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
