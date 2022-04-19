using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepublicaDeLosCocos.Core.DTOs;
using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriageController : ControllerBase
    {
        private readonly ITriageService _triageService;
        private readonly IMapper _mapper;
        public TriageController(ITriageService triageService, IMapper mapper)
        {
            _triageService = triageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var triages = await _triageService.GetTriages();
            var triagesDTO = _mapper.Map<IEnumerable<TriageDTO>>(triages);
            return Ok(triagesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostTriage(TriageDTO triageDTO)
        {
            var triage = _mapper.Map<Triage>(triageDTO);
            await _triageService.InsertTriage(triage);

            triageDTO = _mapper.Map<TriageDTO>(triage);
            return Ok(triageDTO);
        }
    }
}
