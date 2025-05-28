using Events.Application.Dto.Evento;
using Events.Domain.Entities;
using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Alerta
{
    public record ObterAlertaCompletoDTO(
        string IdAlerta,
        string IdEvento,
        NivelAlerta NivelAlerta,
        string MensagemAlerta,
        DateTime DataHoraAlerta,
        EventoEntityDTO Evento
    );
}
