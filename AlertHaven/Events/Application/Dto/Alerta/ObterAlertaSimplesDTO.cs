using Events.Domain.Entities.Enums;

namespace Events.Application.Dto.Alerta
{
    public record ObterAlertaSimplesDTO(
        string IdAlerta,
        string IdEvento,
        NivelAlerta NivelAlerta
    );
}
