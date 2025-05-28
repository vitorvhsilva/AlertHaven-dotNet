using Events.Application.Dto.Iot;
using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Evento
{
    public record EventoSimplesDTO(
        string IdEvento,
        string IdIot,
        TipoEvento TipoEvento,
        IntensidadeEvento IntensidadeEvento,
        string LatitudeEvento,
        string LongitudeEvento,
        DateTime DataHoraEvento
    );
}
