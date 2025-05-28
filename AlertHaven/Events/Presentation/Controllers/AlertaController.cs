using AutoMapper;
using Events.Application.Dto.Alerta;
using Events.Application.Interfaces;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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

        //IEnumerable<ObterAlertaSimplesDTO>
        [HttpGet]
        public IActionResult ObterTodosOsAlertas()
        {
            var entitys = _alertaService.ObterTodosOsAlertas();

            var output = _mapper.Map<IEnumerable<AlertaEntity>, IEnumerable<ObterAlertaSimplesDTO>>(entitys);

            return Ok(output);
        }

        //ObterAlertaCompletoDTO
        [HttpGet("{id}")]
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

        //ObterAlertaSimplesDTO
        [HttpGet("iot/{IdIot}")]
        public IActionResult ObterTodosOsAlertasPorEvento(string IdIot)
        {
            var entitys = _alertaService.ObterTodosOsAlertasPorEvento(IdIot);

            var output = _mapper.Map<IEnumerable<AlertaEntity>, IEnumerable<ObterAlertaSimplesDTO>>(entitys);

            return Ok(output);
        }

        //PersistirAlertaOutputDTO
        [HttpPost]
        public IActionResult PersistirAlerta([FromBody] PersistirAlertaInputDTO dto)
        {
            var alerta = _mapper.Map<PersistirAlertaInputDTO, AlertaEntity>(dto);
            var entity = _alertaService.PersistirAlerta(alerta);
            var output = _mapper.Map<AlertaEntity, PersistirAlertaOutputDTO>(entity);

            return CreatedAtAction(nameof(ObterAlertaPorId), new { IdAlerta = output.IdAlerta}, output);
        }

        //ObterAlertaCompletoDTO
        [HttpPatch("{id}")]
        public IActionResult AtualizarAlerta(string id, [FromBody] AtualizarAlertaInputDTO dto)
        {
            var alerta = _mapper.Map<AtualizarAlertaInputDTO, AlertaEntity>(dto);
            var entity = _alertaService.AtualizarAlerta(alerta, id);

            if (entity is null)
            {
                return NotFound("Não foi possível localizar um Alerta com esse Id");
            }

            var output = _mapper.Map<AlertaEntity, ObterAlertaCompletoDTO>(entity);

            return Ok(output);
        }

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
