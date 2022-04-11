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
    public class SurgeryController : ControllerBase
    {
        private readonly ISurgeryRepository _surgeryRepository;
        private readonly IMapper _mapper;

        public SurgeryController(ISurgeryRepository surgeryRepository, IMapper mapper)
        {
            _surgeryRepository = surgeryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurgerys()
        {
            var surgerys = await _surgeryRepository.GetSurgerys();
            var surgerysDTO = _mapper.Map<IEnumerable<SurgeryDTO>>(surgerys);

            var response = new ApiResponse<IEnumerable<SurgeryDTO>>(surgerysDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgery(int id)
        {
            var surgery = await _surgeryRepository.GetSurgery(id);
            var surgeryDTO = _mapper.Map<SurgeryDTO>(surgery);

            var response = new ApiResponse<SurgeryDTO>(surgeryDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostSurgery(SurgeryDTO surgeryDTO)
        {
            var surgery = _mapper.Map<Surgery>(surgeryDTO);

            await _surgeryRepository.InsertSurgery(surgery);

            surgeryDTO = _mapper.Map<SurgeryDTO>(surgery);
            var response = new ApiResponse<SurgeryDTO>(surgeryDTO);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurgery(int id)
        {
            var result = await _surgeryRepository.DeleteSurgery(id);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
