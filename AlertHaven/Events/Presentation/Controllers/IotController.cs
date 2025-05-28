using AutoMapper;
using Events.Application.Dto.Iot;
using Events.Application.Interfaces;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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

        [SwaggerOperation(
            Summary = "Listar todos os dispositivos IoT",
            Description = "Retorna uma lista simplificada de todos os dispositivos IoT cadastrados"
        )]
        [SwaggerResponse(200, "Lista de dispositivos IoT obtida com sucesso", typeof(IEnumerable<ObterIotSimplesDTO>))]
        [HttpGet]
        //IEnumerable<ObterIotSimplesDTO>
        public IActionResult ObterTodosOsIots()
        {
            var entitys = _iotService.ObterTodosOsIots();

            var output = _mapper.Map<IEnumerable<IotEntity>, IEnumerable<ObterIotSimplesDTO>>(entitys);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Obter dispositivo IoT completo",
            Description = "Retorna todos os detalhes de um dispositivo IoT específico"
        )]
        [SwaggerResponse(200, "Dispositivo IoT encontrado com sucesso", typeof(ObterIotCompletoDTO))]
        [SwaggerResponse(404, "Dispositivo IoT não encontrado")]
        [HttpGet("{id}")]
        //ObterIotCompletoDTO
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

        [SwaggerOperation(
            Summary = "Cadastrar novo dispositivo IoT",
            Description = "Cria um novo dispositivo IoT no sistema"
        )]
        [SwaggerResponse(201, "Dispositivo IoT criado com sucesso", typeof(PersistirIotOutputDTO))]
        [SwaggerResponse(400, "Dados inválidos fornecidos")]
        [HttpPost]
        //PersistirIotOutputDTO
        public IActionResult PersistirIot([FromBody] PersistirIotInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iot = _mapper.Map<PersistirIotInputDTO, IotEntity>(dto);
            var entity = _iotService.PersistirIot(iot);
            var output = _mapper.Map<IotEntity, PersistirIotOutputDTO>(entity);

            return CreatedAtAction(nameof(ObterIotPorId), new { IdIot = output.IdIot }, output);
        }

        [SwaggerOperation(
            Summary = "Atualizar dispositivo IoT",
            Description = "Atualiza as informações de um dispositivo IoT existente"
        )]
        [SwaggerResponse(200, "Dispositivo IoT atualizado com sucesso", typeof(ObterIotCompletoDTO))]
        [SwaggerResponse(400, "Dados inválidos fornecidos")]
        [SwaggerResponse(404, "Dispositivo IoT não encontrado")]
        [HttpPatch("{id}")]
        //ObterIotCompletoDTO
        public IActionResult AtualizarIot(string id, [FromBody] AtualizarIotInputDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var iot = _mapper.Map<AtualizarIotInputDTO, IotEntity>(dto);
            var entity = _iotService.AtualizarIot(iot, id);

            if (entity is null)
            {
                return NotFound("Não foi possível localizar um Iot com esse Id");
            }

            var output = _mapper.Map<IotEntity, ObterIotCompletoDTO>(entity);

            return Ok(output);
        }

        [SwaggerOperation(
            Summary = "Remover dispositivo IoT",
            Description = "Exclui permanentemente um dispositivo IoT do sistema"
        )]
        [SwaggerResponse(204, "Dispositivo IoT removido com sucesso")]
        [SwaggerResponse(404, "Dispositivo IoT não encontrado")]
        [HttpDelete("{id}")]
        public IActionResult DeletarIot(string id)
        {
            var entity = _iotService.DeletarIot(id);
            if (entity is null)
                return NotFound("Não foi possível localizar um Iot com esse Id");

            return NoContent();
        }
    }
}