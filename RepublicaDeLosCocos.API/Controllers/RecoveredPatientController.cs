using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.API.Responses;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoveredPatientController : ControllerBase
    {
        private readonly IRecoveredPatientService _recoveredPatientService;
        private readonly IMapper _mapper;

        public RecoveredPatientController(IRecoveredPatientService  recoveredPatientService, IMapper mapper)
        {
            _recoveredPatientService = recoveredPatientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecoveredPatients()
        {
            var recoveredPatients = await _recoveredPatientService.GetRecoveredPatients();
            var recoveredPatientsDto = _mapper.Map<IEnumerable<PatientDTO>>(recoveredPatients);

            var response = new ApiResponse<IEnumerable<PatientDTO>>(recoveredPatientsDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> RecoveredPatient(int id)
        {
            var result = await _recoveredPatientService.RecoveredPatient(id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
