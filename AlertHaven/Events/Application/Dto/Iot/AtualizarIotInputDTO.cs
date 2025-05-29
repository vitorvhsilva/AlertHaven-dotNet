using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Application.Dto.Iot
{
    public record AtualizarIotInputDTO(
        [Required(ErrorMessage = $"Campo {nameof(LatitudeIot)} é obrigatorio")]
        string LatitudeIot,
        
        [Required(ErrorMessage = $"Campo {nameof(LongitudeIot)} é obrigatorio")]
        string LongitudeIot,
        
        [Required(ErrorMessage = $"Campo {nameof(UltimaLeituraIot)} é obrigatorio")]
        double UltimaLeituraIot,

        [Required(ErrorMessage = $"Campo {nameof(TipoIot)} é obrigatorio")]
        TipoIot TipoIot,

        [Required(ErrorMessage = $"Campo {nameof(UnidadeMedidaIot)} é obrigatorio")]
        UnidadeMedidaIot UnidadeMedidaIot,

        [Required(ErrorMessage = $"Campo {nameof(StatusIot)} é obrigatorio")]
        StatusIot StatusIot
    );
}
