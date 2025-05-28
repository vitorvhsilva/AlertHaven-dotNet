using Events.Domain.Entities.Enums;

namespace Events.Application.Dto
{
    public record PersistirIotInputDTO(
        TipoIot TipoIot,
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
