using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Evento
{
    public record AtualizarEventoInputDTO(
        TipoEvento TipoEvento,
        IntensidadeEvento IntensidadeEvento
    );
}
