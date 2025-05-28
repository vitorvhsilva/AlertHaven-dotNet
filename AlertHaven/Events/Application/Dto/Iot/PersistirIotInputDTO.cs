using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Iot
{
    public record PersistirIotInputDTO(
        TipoIot TipoIot,
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
