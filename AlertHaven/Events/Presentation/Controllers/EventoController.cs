using AutoMapper;
using Events.Application.Dto.Evento;
using Events.Application.Dto.Iot;
using Events.Application.Interfaces;
using Events.Application.Services;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventoService _eventoService;

        public EventoController(IMapper mapper, IEventoService eventoService)
        {
            _mapper = mapper;
            _eventoService = eventoService;
        }

        //IEnumerable<ObterEventoSimplesDTO>
        [HttpGet]
        public IActionResult ObterTodosOsEventos()
        {
            var entitys = _eventoService.ObterTodosOsEventos();

            var output = _mapper.Map<IEnumerable<EventoEntity>, IEnumerable<ObterEventoSimplesDTO>>(entitys);

            return Ok(output);
        }

        //ObterEventoCompletoDTO
        [HttpGet("{id}")]
        public IActionResult ObterEventoPorId(string id)
        {
            var entity = _eventoService.ObterEventoPorId(id);
            var output = _mapper.Map<EventoEntity, ObterEventoCompletoDTO>(entity);

            if (output is null)
            {
                return NotFound("Não foi possível localizar um Evento com esse Id");
            }

            return Ok(output);
        }

        //ObterEventoSimplesDTO
        [HttpGet("iot/{IdIot}")]
        public IActionResult ObterTodosOsEventosPorIot(string IdIot)
        {
            var entitys = _eventoService.ObterTodosOsEventosPorIot(IdIot);

            var output = _mapper.Map<IEnumerable<EventoEntity>, IEnumerable<ObterEventoSimplesDTO>>(entitys);

            return Ok(output);
        }

        //PersistirEventoOutputDTO
        [HttpPost]
        public IActionResult PersistirEvento([FromBody] PersistirEventoInputDTO dto)
        {
            var iot = _mapper.Map<PersistirEventoInputDTO, EventoEntity>(dto);
            var entity = _eventoService.PersistirEvento(iot);
            var output = _mapper.Map<EventoEntity, PersistirEventoOutputDTO>(entity);

            return CreatedAtAction(nameof(ObterEventoPorId), new { IdEvento = output.IdEvento}, output);
        }

        //ObterEventoCompletoDTO
        [HttpPatch("{id}")]
        public IActionResult AtualizarEvento(string id, [FromBody] AtualizarEventoInputDTO dto)
        {
            var iot = _mapper.Map<AtualizarEventoInputDTO, EventoEntity>(dto);
            var entity = _eventoService.AtualizarEvento(iot, id);

            if (entity is null)
            {
                return NotFound("Não foi possível localizar um Evento com esse Id");
            }

            var output = _mapper.Map<EventoEntity, ObterEventoCompletoDTO>(entity);

            return Ok(output);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEvento(string id)
        {
            var entity = _eventoService.DeletarEvento(id);
            if (entity is null)
                return NotFound("Não foi possível localizar um Evento com esse Id");

            return NoContent();
        }
    }
}
