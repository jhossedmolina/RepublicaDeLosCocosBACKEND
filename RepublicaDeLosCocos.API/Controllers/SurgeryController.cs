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
    public class SurgeryController : ControllerBase
    {
        private readonly ISurgeryService _surgeryService;
        private readonly IMapper _mapper;

        public SurgeryController(ISurgeryService surgeryService, IMapper mapper)
        {
            _surgeryService = surgeryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurgerys()
        {
            var surgerys = await _surgeryService.GetSurgerys();
            var surgerysDTO = _mapper.Map<IEnumerable<SurgeryDTO>>(surgerys);

            //var response = new ApiResponse<IEnumerable<SurgeryDTO>>(surgerysDTO);
            return Ok(surgerysDTO);
        }

        [HttpGet]
        [Route("SurgeryInCare")]
        public async Task<IActionResult> GetSurgerysInCare()
        {
            var surgerysInCare = await _surgeryService.GetSurgerysInCare();
            var surgerysInCareDTO = _mapper.Map<IEnumerable<SurgeryDTO>>(surgerysInCare);
            return Ok(surgerysInCareDTO);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgery(int id)
        {
            var surgery = await _surgeryService.GetSurgery(id);
            var surgeryDTO = _mapper.Map<SurgeryDTO>(surgery);

            //var response = new ApiResponse<SurgeryDTO>(surgeryDTO);
            return Ok(surgeryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostSurgery(SurgeryDTO surgeryDTO)
        {
            var surgery = _mapper.Map<Surgery>(surgeryDTO);

            await _surgeryService.InsertSurgery(surgery);

            surgeryDTO = _mapper.Map<SurgeryDTO>(surgery);
            //var response = new ApiResponse<SurgeryDTO>(surgeryDTO);
            return Ok(surgeryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurgery(int id)
        {
            var result = await _surgeryService.DeleteSurgery(id);

            //var response = new ApiResponse<bool>(result);
            return Ok(result);
        }
    }
}
