using AutoMapper;
using Events.Application.Dto;
using Events.Application.Interfaces;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IotController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIotService _iotService;

        public IotController(IMapper mapper, IIotService iotService)
        {
            _mapper = mapper;
            _iotService = iotService;
        }

        //IEnumerable<ObterIotSimplesDTO>
        [HttpGet]
        public IActionResult ObterTodosOsIots()
        {
            return Ok();
        }

        //ObterIotCompletoDTO
        [HttpGet("{id}")]
        public IActionResult ObterIotPorId(int id)
        {
            return Ok();
        }

        //PersistirIotOutputDTO
        [HttpPost]
        public IActionResult PersistirIot([FromBody] PersistirIotInputDTO dto)
        {
            var iot = _mapper.Map<PersistirIotInputDTO, IotEntity>(dto);
            var entity = _iotService.PersistirIot(iot);
            var output = _mapper.Map<IotEntity, PersistirIotOutputDTO>(entity);

            return CreatedAtAction(nameof(ObterIotPorId), new { IdIot = output.IdIot}, output);
        }

        //AtualizarIotOutputDTO
        [HttpPut("{id}")]
        public IActionResult AtualizarIot(int id, [FromBody]string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarIot(int id)
        {
            return Ok();
        }
    }
}
