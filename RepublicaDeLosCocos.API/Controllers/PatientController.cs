using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.API.Responses;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper; 
        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientService.GetPatients();
            var patientsDto = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            var response = new ApiResponse<IEnumerable<PatientDTO>>(patientsDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientService.GetPatient(id);
            var patientDto = _mapper.Map<PatientDTO>(patient);

            var response = new ApiResponse<PatientDTO>(patientDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientService.InsertPatient(patient);

            patientDto = _mapper.Map<PatientDTO>(patient);

            var response = new ApiResponse<PatientDTO>(patientDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(int id, UnrecoveredPatientDTO patientDto)
        {
            var patient = _mapper.Map<UnrecoveredPatient>(patientDto);
            var result = await _patientService.UpdatePatient(id, patient);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
