using AutoMapper;
using Events.Application.Dto.Evento;
using Events.Application.Dto.Iot;
using Events.Application.Interfaces;
using Events.Application.Services;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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

        [SwaggerOperation(
            Summary = "Listar todos os eventos",
            Description = "Retorna uma lista simplificada de todos os eventos cadastrados"
        )]
        [SwaggerResponse(200, "Lista de eventos obtida com sucesso", typeof(IEnumerable<ObterEventoSimplesDTO>))]
        [HttpGet]
        //IEnumerable<ObterEventoSimplesDTO>
        public IActionResult ObterTodosOsEventos()
        {
            var entitys = _eventoService.ObterTodosOsEventos();

            var output = _mapper.Map<IEnumerable<EventoEntity>, IEnumerable<ObterEventoSimplesDTO>>(entitys);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Obter evento completo",
            Description = "Retorna todos os detalhes de um evento específico"
        )]
        [SwaggerResponse(200, "Evento encontrado com sucesso", typeof(ObterEventoCompletoDTO))]
        [SwaggerResponse(404, "Evento não encontrado")]
        [HttpGet("{id}")]
        //ObterEventoCompletoDTO
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

        [SwaggerOperation(
            Summary = "Listar eventos por IoT",
            Description = "Retorna eventos associados a um dispositivo IoT específico"
        )]
        [SwaggerResponse(200, "Eventos encontrados com sucesso", typeof(IEnumerable<ObterEventoSimplesDTO>))]
        [HttpGet("iot/{IdIot}")]
        //ObterEventoSimplesDTO
        public IActionResult ObterTodosOsEventosPorIot(string IdIot)
        {
            var entitys = _eventoService.ObterTodosOsEventosPorIot(IdIot);

            var output = _mapper.Map<IEnumerable<EventoEntity>, IEnumerable<ObterEventoSimplesDTO>>(entitys);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Criar novo evento",
            Description = "Cadastra um novo evento no sistema"
        )]
        [SwaggerResponse(201, "Evento criado com sucesso", typeof(PersistirEventoOutputDTO))]
        [SwaggerResponse(400, "Dados inválidos fornecidos")]
        [HttpPost]
        //PersistirEventoOutputDTO
        public IActionResult PersistirEvento([FromBody] PersistirEventoInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iot = _mapper.Map<PersistirEventoInputDTO, EventoEntity>(dto);
            var entity = _eventoService.PersistirEvento(iot);
            var output = _mapper.Map<EventoEntity, PersistirEventoOutputDTO>(entity);

            return CreatedAtAction(nameof(ObterEventoPorId), new { IdEvento = output.IdEvento }, output);
        }

        [SwaggerOperation(
            Summary = "Atualizar evento",
            Description = "Atualiza as informações de um evento existente"
        )]
        [SwaggerResponse(200, "Evento atualizado com sucesso", typeof(ObterEventoCompletoDTO))]
        [SwaggerResponse(400, "Dados inválidos fornecidos")]
        [SwaggerResponse(404, "Evento não encontrado")]
        [HttpPatch("{id}")]
        //ObterEventoCompletoDTO
        public IActionResult AtualizarEvento(string id, [FromBody] AtualizarEventoInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iot = _mapper.Map<AtualizarEventoInputDTO, EventoEntity>(dto);
            var entity = _eventoService.AtualizarEvento(iot, id);

            if (entity is null)
            {
                return NotFound("Não foi possível localizar um Evento com esse Id");
            }

            var output = _mapper.Map<EventoEntity, ObterEventoCompletoDTO>(entity);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Excluir evento",
            Description = "Remove permanentemente um evento do sistema"
        )]
        [SwaggerResponse(204, "Evento excluído com sucesso")]
        [SwaggerResponse(404, "Evento não encontrado")]
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