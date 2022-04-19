using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class VirusTestController : ControllerBase
    {
        private readonly IVirusTestRepository _virusTestRepository;
        private readonly IMapper _mapper;


        public VirusTestController(IVirusTestRepository virusTestRepository, IMapper mapper)
        {
            _virusTestRepository = virusTestRepository;
            _mapper = mapper;
        }

        [HttpPut]
        public async Task<IActionResult> PostTestFile(int id, [FromForm]VirusTestFileDTO virusTestFileDTO)
        {
            var testFIle = _mapper.Map<VirusTestFile>(virusTestFileDTO);
            await _virusTestRepository.InsertTestFile(virusTestFileDTO, id);

            virusTestFileDTO = _mapper.Map<VirusTestFileDTO>(testFIle);
            //var response = new ApiResponse<VirusTestFileDTO>(virusTestFileDTO);
            return Ok(virusTestFileDTO);
        }
    }
}
