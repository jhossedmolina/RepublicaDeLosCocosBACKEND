using AutoMapper;
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
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper; 
        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientRepository.GetPatients();
            var patientsDto = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            var response = new ApiResponse<IEnumerable<PatientDTO>>(patientsDto);
            return Ok(patientsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            var patientDto = _mapper.Map<PatientDTO>(patient);

            var response = new ApiResponse<PatientDTO>(patientDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientRepository.InsertPatient(patient);

            patientDto = _mapper.Map<PatientDTO>(patient);

            var response = new ApiResponse<PatientDTO>(patientDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(int id, PatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            var result = await _patientRepository.UpdatePatient(patient);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }




    }
}
