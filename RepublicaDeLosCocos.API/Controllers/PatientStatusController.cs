using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientStatusController : ControllerBase
    {
        private readonly IPatientStatusService _patientStatusService;
        private readonly IMapper _mapper;

        public PatientStatusController(IPatientStatusService patientStatusService, IMapper mapper)
        {
            _patientStatusService = patientStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientsStatus()
        {
            var patientStatus = await _patientStatusService.GetPatientsStatus();
            var patienStatusDTO = _mapper.Map<IEnumerable<PatientStatusDTO>>(patientStatus);
            return Ok(patienStatusDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatientStatus(PatientStatusDTO patientStatusDTO)
        {
            var patientStatus = _mapper.Map<PatientStatus>(patientStatusDTO);
            await _patientStatusService.InsertPatientStatus(patientStatus);

            patientStatusDTO = _mapper.Map<PatientStatusDTO>(patientStatus);
            return Ok(patientStatusDTO);
        }
    }
}
