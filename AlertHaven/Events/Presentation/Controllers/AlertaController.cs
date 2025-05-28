using AutoMapper;
using Events.Application.Dto.Alerta;
using Events.Application.Interfaces;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlertaService _alertaService;

        public AlertaController(IMapper mapper, IAlertaService alertaService)
        {
            _mapper = mapper;
            _alertaService = alertaService;
        }

        [SwaggerOperation(
            Summary = "Obter todos os alertas",
            Description = "Retorna uma lista simplificada de todos os alertas cadastrados"
        )]
        [SwaggerResponse(200, "Lista de alertas obtida com sucesso", typeof(IEnumerable<ObterAlertaSimplesDTO>))]
        [HttpGet]
        //IEnumerable<ObterAlertaSimplesDTO>
        public IActionResult ObterTodosOsAlertas()
        {
            var entitys = _alertaService.ObterTodosOsAlertas();

            var output = _mapper.Map<IEnumerable<AlertaEntity>, IEnumerable<ObterAlertaSimplesDTO>>(entitys);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Obter alerta completo por ID",
            Description = "Retorna todos os detalhes de um alerta específico"
        )]
        [SwaggerResponse(200, "Alerta encontrado com sucesso", typeof(ObterAlertaCompletoDTO))]
        [SwaggerResponse(404, "Alerta não encontrado")]
        [HttpGet("{id}")]
        //ObterAlertaCompletoDTO
        public IActionResult ObterAlertaPorId(string id)
        {
            var entity = _alertaService.ObterAlertaPorId(id);
            var output = _mapper.Map<AlertaEntity, ObterAlertaCompletoDTO>(entity);

            if (output is null)
            {
                return NotFound("Não foi possível localizar um Alerta com esse Id");
            }

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Obter alertas por evento",
            Description = "Retorna alertas simplificados associados a um evento"
        )]
        [SwaggerResponse(200, "Alertas encontrados com sucesso", typeof(IEnumerable<ObterAlertaSimplesDTO>))]
        [HttpGet("evento/{IdEvento}")]
        //ObterAlertaSimplesDTO
        public IActionResult ObterTodosOsAlertasPorEvento(string IdEvento)
        {
            var entitys = _alertaService.ObterTodosOsAlertasPorEvento(IdEvento);

            var output = _mapper.Map<IEnumerable<AlertaEntity>, IEnumerable<ObterAlertaSimplesDTO>>(entitys);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Criar novo alerta",
            Description = "Persiste um novo alerta no sistema"
        )]
        [SwaggerResponse(201, "Alerta criado com sucesso", typeof(PersistirAlertaOutputDTO))]
        [SwaggerResponse(400, "Dados inválidos fornecidos")]
        [HttpPost]
        //PersistirAlertaOutputDTO
        public IActionResult PersistirAlerta([FromBody] PersistirAlertaInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alerta = _mapper.Map<PersistirAlertaInputDTO, AlertaEntity>(dto);
            var entity = _alertaService.PersistirAlerta(alerta);
            var output = _mapper.Map<AlertaEntity, PersistirAlertaOutputDTO>(entity);

            return CreatedAtAction(nameof(ObterAlertaPorId), new { IdAlerta = output.IdAlerta }, output);
        }

        [SwaggerOperation(
            Summary = "Atualizar alerta",
            Description = "Atualiza as informações de um alerta existente"
        )]
        [SwaggerResponse(200, "Alerta atualizado com sucesso", typeof(ObterAlertaCompletoDTO))]
        [SwaggerResponse(400, "Dados inválidos fornecidos")]
        [SwaggerResponse(404, "Alerta não encontrado")]
        [HttpPatch("{id}")]
        //ObterAlertaCompletoDTO
        public IActionResult AtualizarAlerta(string id, [FromBody] AtualizarAlertaInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alerta = _mapper.Map<AtualizarAlertaInputDTO, AlertaEntity>(dto);
            var entity = _alertaService.AtualizarAlerta(alerta, id);

            if (entity is null)
            {
                return NotFound("Não foi possível localizar um Alerta com esse Id");
            }

            var output = _mapper.Map<AlertaEntity, ObterAlertaCompletoDTO>(entity);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Excluir alerta",
            Description = "Remove permanentemente um alerta do sistema"
        )]
        [SwaggerResponse(204, "Alerta excluído com sucesso")]
        [SwaggerResponse(404, "Alerta não encontrado")]
        [HttpDelete("{id}")]
        public IActionResult DeletarAlerta(string id)
        {
            var entity = _alertaService.DeletarAlerta(id);
            if (entity is null)
                return NotFound("Não foi possível localizar um Alerta com esse Id");

            return NoContent();
        }
    }
}