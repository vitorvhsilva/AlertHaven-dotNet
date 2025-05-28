using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Iot
{
    public record AtualizarIotInputDTO(
        TipoIot TipoIot,
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
