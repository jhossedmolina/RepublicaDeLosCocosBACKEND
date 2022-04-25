using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalConsultationController : ControllerBase
    {
        private readonly IMedicalConsultationService _medicalConsultationService;
        private readonly IMapper _mapper;
        public MedicalConsultationController(IMedicalConsultationService medicalConsultationService, IMapper mapper)
        {
            _medicalConsultationService = medicalConsultationService;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("IngresarDiagnosticoDelPacienteEnAtencion")]
        public async Task<IActionResult> PutPatientDiagnostic(int id, PatientDiagnosticDTO patientDiagnosticDTO)
        {
            var diagnostic = _mapper.Map<PatientDiagnostic>(patientDiagnosticDTO);
            var result = await _medicalConsultationService.UpdatePatientDiagnostic(id, diagnostic);

            //var response = new ApiResponse<bool>(result);
            return Ok(result);
        }

        [HttpPut]
        [Route("EnviarPacienteEnAtencionARecuperacion")]
        public async Task<IActionResult> RecoveredPatient(int id)
        {
            var result = await _medicalConsultationService.RecoveredPatient(id);

            //var response = new ApiResponse<bool>(result);
            return Ok(result);
        }

        [HttpPut]
        [Route("ActualizarTriageDelPacienteEnAtencion")]
        public async Task<IActionResult> PutPatientTriage(int id, UnrecoveredPatientDTO unrecoveredPatientDTO)
        {
            var patient = _mapper.Map<UnrecoveredPatient>(unrecoveredPatientDTO);
            var result = await _medicalConsultationService.UpdatePatientTriage(id, patient);

            //var response = new ApiResponse<bool>(result);
            return Ok(result);
        }
    }
}
