using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Events.Application.Dto.Evento
{
    public record AtualizarEventoInputDTO(
        [Required(ErrorMessage = $"Campo {nameof(TipoEvento)} é obrigatorio")]
        TipoEvento TipoEvento,

        [Required(ErrorMessage = $"Campo {nameof(IntensidadeEvento)} é obrigatorio")]
        IntensidadeEvento IntensidadeEvento
    );
}
