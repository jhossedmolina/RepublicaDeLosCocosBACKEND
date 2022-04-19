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
    public class SurgeryStatusController : ControllerBase
    {
        private readonly ISurgeryStatusService _surgeryStatusService;
        private readonly IMapper _mapper;

        public SurgeryStatusController(ISurgeryStatusService surgeryStatusService, IMapper mapper)
        {
            _surgeryStatusService = surgeryStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurgerysStatus()
        {
            var surgeryStatus = await _surgeryStatusService.GetSurgerysStatus();
            var surgeryStatusDTO = _mapper.Map<IEnumerable<SurgeryStatusDTO>>(surgeryStatus);
            return Ok(surgeryStatusDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostSurgeryStatus(SurgeryStatusDTO surgeryStatusDTO)
        {
            var surgeryStatus = _mapper.Map<SurgeryStatus>(surgeryStatusDTO);
            await _surgeryStatusService.InsertSurgeryStatus(surgeryStatus);

            surgeryStatusDTO = _mapper.Map<SurgeryStatusDTO>(surgeryStatus);
            return Ok(surgeryStatusDTO);
        }
    }
}
