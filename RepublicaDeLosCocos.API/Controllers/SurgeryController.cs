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
            return Ok(surgerysDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostSurgery(SurgeryDTO surgeryDTO)
        {
            var surgery = _mapper.Map<Surgery>(surgeryDTO);
            await _surgeryRepository.InsertSurgery(surgery);
            return Ok(surgery);
        }
    }
}
