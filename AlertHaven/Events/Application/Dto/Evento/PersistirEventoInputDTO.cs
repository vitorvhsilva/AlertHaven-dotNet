using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Events.Application.Dto.Evento
{
    public record PersistirEventoInputDTO(
        [Required(ErrorMessage = $"Campo {nameof(IdIot)} é obrigatorio")]
        string IdIot,

        [Required(ErrorMessage = $"Campo {nameof(TipoEvento)} é obrigatorio")]
        TipoEvento TipoEvento,

        [Required(ErrorMessage = $"Campo {nameof(IntensidadeEvento)} é obrigatorio")]
        IntensidadeEvento IntensidadeEvento,

        [Required(ErrorMessage = $"Campo {nameof(LatitudeEvento)} é obrigatorio")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Campo deve ter no minimo 10 caracteres")]
        string LatitudeEvento,

        [Required(ErrorMessage = $"Campo {nameof(LongitudeEvento)} é obrigatorio")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Campo deve ter no minimo 10 caracteres")]
        string LongitudeEvento,

        [Required(ErrorMessage = $"Campo {nameof(DataHoraEvento)} é obrigatorio")]
        DateTime DataHoraEvento
    );
}
