using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Evento
{
    public record ObterEventoSimplesDTO(
        string IdEvento,
        string IdIot,
        TipoEvento TipoEvento,
        IntensidadeEvento IntensidadeEvento
    );
}
