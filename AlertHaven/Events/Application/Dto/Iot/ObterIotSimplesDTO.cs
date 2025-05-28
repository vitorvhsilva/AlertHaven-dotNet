using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Iot
{
    public record ObterIotSimplesDTO(
        string IdIot,
        TipoIot TipoIot,
        string? LatitudeIot,
        string? LongitudeIot,
        double? UltimaLeituraIot,
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
