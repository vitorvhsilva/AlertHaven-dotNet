using Events.Application.Dto.Evento;
using Events.Domain.Entities;
using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Events.Application.Dto.Alerta
{
    public record PersistirAlertaInputDTO(
        [Required(ErrorMessage = $"Campo {nameof(IdEvento)} é obrigatorio")]
        string IdEvento,

        [Required(ErrorMessage = $"Campo {nameof(NivelAlerta)} é obrigatorio")]
        NivelAlerta NivelAlerta,

        [Required(ErrorMessage = $"Campo {nameof(MensagemAlerta)} é obrigatorio")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Campo deve ter no minimo 10 caracteres")]
        string MensagemAlerta,

        [Required(ErrorMessage = $"Campo {nameof(DataHoraAlerta)} é obrigatorio")]
        DateTime DataHoraAlerta
    );
}
