using Events.Domain.Entities.Enums;

namespace Events.Application.Dto
{
    public record PersistirIotOutputDTO(
        string IdIot,
        TipoIot TipoIot,
        string LatitudeIot,
        string LongitudeIot,
        double UltimaLeituraIot,
        DateTime DataHoraUltimaLeituraIot,
        UnidadeMedidaIot UnidadeMedidaIot
    );
}
