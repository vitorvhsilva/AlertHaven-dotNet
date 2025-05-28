using Events.Application.Dto.Evento;
using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Alerta
{
    public record AtualizarAlertaInputDTO(
        NivelAlerta NivelAlerta,
        string MensagemAlerta
    );
}
