using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Interfaces
{
    public interface IVirusTestRepository
    {
        Task<bool> InsertTestFile([FromForm] VirusTestFileDTO testFile, int id);
    }
}
