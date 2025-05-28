using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Alerta
{
    public record AlertaSimplesDTO(
        string IdAlerta,
        string IdEvento,
        NivelAlerta NivelAlerta,
        string MensagemAlerta,
        DateTime DataHoraAlerta
    );
}
