using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.API.Responses;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignPatientController : ControllerBase
    {
        private readonly IAssignPatientService _assignPatientService;
        private readonly IMapper _mapper;

        public AssignPatientController(IAssignPatientService assignPatientService, IMapper mapper)
        {
            _assignPatientService = assignPatientService;
            _mapper = mapper;
        }

       [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignPatient(int id)
        {
            var assign = await _assignPatientService.GetPatient(id);
            var assignPatientDto = _mapper.Map<AssignPatientDTO>(assign);

            var response = new ApiResponse<AssignPatientDTO>(assignPatientDto);
            return Ok(response);
        }
    }
}
