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
    public class TreatedController : ControllerBase
    {
        private readonly ITreatedRepository _treatedRepository;
        private readonly IMapper _mapper;

        public TreatedController(ITreatedRepository treatedRepository, IMapper mapper)
        {
            _treatedRepository = treatedRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var treateds = await _treatedRepository.GetPatientsAssigned();
            var treatedsDTO = _mapper.Map<IEnumerable<TreatedDTO>>(treateds);
            return Ok(treatedsDTO);
        }
    }
}
