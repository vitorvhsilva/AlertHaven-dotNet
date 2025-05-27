using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Domain.Entities
{
    public class IotEntity
    {
        public string IdIot { get; set; } 
        public TipoIot TipoIot { get; set; }
        public string LatitudeIot { get; set; }
        public string LongitudeIot { get; set; }
        public double UltimaLeituraIot { get; set; }
        public UnidadeMedidaIot UnidadeMedidaIot { get; set; }
        public StatusIot StatusIot { get; set; }
    }
}
