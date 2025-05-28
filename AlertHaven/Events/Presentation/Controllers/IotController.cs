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
            var entitys = _iotService.ObterTodosOsIots();

            var output = _mapper.Map<IEnumerable<IotEntity>, IEnumerable<ObterIotSimplesDTO>>(entitys);

            return Ok(output);
        }

        //ObterIotCompletoDTO
        [HttpGet("{id}")]
        public IActionResult ObterIotPorId(string id)
        {
            var entity = _iotService.ObterIotPorId(id);
            var output = _mapper.Map<IotEntity, ObterIotCompletoDTO>(entity);

            if (output is null)
            {
                return NotFound("Não foi possível localizar um Iot com esse Id");
            }

            return Ok(output);
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

        //ObterIotCompletoDTO
        [HttpPatch("{id}")]
        public IActionResult AtualizarIot(string id, [FromBody] AtualizarIotInputDTO dto)
        {
            var iot = _mapper.Map<AtualizarIotInputDTO, IotEntity>(dto);
            var entity = _iotService.AtualizarIot(iot, id);

            if (entity is null)
            {
                return NotFound("Não foi possível localizar um Iot com esse Id");
            }

            var output = _mapper.Map<IotEntity, PersistirIotOutputDTO>(entity);

            return Ok(output);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarIot(string id)
        {
            return Ok();
        }
    }
}
