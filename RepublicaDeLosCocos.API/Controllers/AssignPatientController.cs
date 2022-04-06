using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignPatientController : ControllerBase
    {
        private readonly IAssignPatientRepository _assignPatientRepository;
        private readonly IMapper _mapper;

        public AssignPatientController(IAssignPatientRepository assignPatientRepository, IMapper mapper)
        {
            _assignPatientRepository = assignPatientRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignPAtient(int id)
        {
            var assign = await _assignPatientRepository.GetPatient(id);
            var assignDto = _mapper.Map<AssignPatientDTO>(assign);
            return Ok(assignDto);
        }
    }
}
