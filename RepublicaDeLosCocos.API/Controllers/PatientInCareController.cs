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
        private readonly IPatientInCareRepository _treatedRepository;
        private readonly IMapper _mapper;

        public PatientInCareController(IPatientInCareRepository treatedRepository, IMapper mapper)
        {
            _treatedRepository = treatedRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var treateds = await _treatedRepository.GetPatientsAssigned();
            var treatedsDTO = _mapper.Map<IEnumerable<PatientInCareDTO>>(treateds);

            var response = new ApiResponse<IEnumerable<PatientInCareDTO>>(treatedsDTO);
            return Ok(response);
        }
    }
}
