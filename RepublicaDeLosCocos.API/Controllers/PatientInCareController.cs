using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IPatientInCareService _patientInCareService;
        private readonly IMapper _mapper;

        public PatientInCareController(IPatientInCareService patientInCareService, IMapper mapper)
        {
            _patientInCareService = patientInCareService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var assigneds = await _patientInCareService.GetPatientsAssigned();
            var assignedsDTO = _mapper.Map<IEnumerable<PatientInCareDTO>>(assigneds);

            //var response = new ApiResponse<IEnumerable<PatientInCareDTO>>(assignedsDTO);
            return Ok(assignedsDTO);
        }
    }
}
