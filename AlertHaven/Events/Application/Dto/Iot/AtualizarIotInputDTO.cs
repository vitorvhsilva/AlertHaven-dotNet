using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Events.Application.Dto.Iot
{
    public record AtualizarIotInputDTO(
        [Required(ErrorMessage = $"Campo {nameof(TipoIot)} é obrigatorio")]
        TipoIot TipoIot,

        [Required(ErrorMessage = $"Campo {nameof(UnidadeMedidaIot)} é obrigatorio")]
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
