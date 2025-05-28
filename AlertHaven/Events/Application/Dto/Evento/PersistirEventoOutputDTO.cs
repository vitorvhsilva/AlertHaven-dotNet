using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Evento
{
    public record PersistirEventoOutputDTO(
        string IdEvento,
        string IdIot,
        TipoEvento TipoEvento,
        IntensidadeEvento IntensidadeEvento,
        string LatitudeEvento,
        string LongitudeEvento,
        DateTime DataHoraEvento
    );
}
