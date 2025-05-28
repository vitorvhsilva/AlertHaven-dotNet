using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Alerta
{
    public record AlertaEntityDTO(
        string IdAlerta,
        string IdEvento,
        NivelAlerta NivelAlerta,
        string MensagemAlerta,
        DateTime DataHoraAlerta
    );
}
