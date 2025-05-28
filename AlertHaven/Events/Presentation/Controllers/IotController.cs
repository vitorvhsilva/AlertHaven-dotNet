using Events.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Events.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IotController : ControllerBase
    {

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
        public IActionResult PersistirIot([FromBody]string value)
        {
            return Ok();
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
