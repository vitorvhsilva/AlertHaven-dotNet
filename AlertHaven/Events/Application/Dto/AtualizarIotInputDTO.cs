using Events.Domain.Entities.Enums;

namespace Events.Application.Dto
{
    public record AtualizarIotInputDTO(
        TipoIot TipoIot,
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
