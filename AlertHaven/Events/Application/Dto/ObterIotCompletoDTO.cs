using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Dto
{
    public record ObterIotCompletoDTO(
        string IdIot,
        TipoIot TipoIot,
        string? LatitudeIot,
        string? LongitudeIot,
        double? UltimaLeituraIot,
        DateTime? DataHoraUltimaLeituraIot,
        UnidadeMedidaIot UnidadeMedidaIot,
        StatusIot? StatusIot,
        ICollection<EventoEntity>? Eventos  
    );
}
