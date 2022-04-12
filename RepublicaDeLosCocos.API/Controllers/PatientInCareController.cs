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
    public class PatientInCareController : ControllerBase
    {
        private readonly IPatientInCareRepository _patientInCareRepository;
        private readonly IMapper _mapper;

        public PatientInCareController(IPatientInCareRepository patientInCareRepository, IMapper mapper)
        {
            _patientInCareRepository = patientInCareRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var assigneds = await _patientInCareRepository.GetPatientsAssigned();
            var assignedsDTO = _mapper.Map<IEnumerable<PatientInCareDTO>>(assigneds);

            var response = new ApiResponse<IEnumerable<PatientInCareDTO>>(assignedsDTO);
            return Ok(response);
        }
    }
}
