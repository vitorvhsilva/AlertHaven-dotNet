using Events.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events.Domain.Entities
{
    [Table("TB_IOT")]
    public class IotEntity
    {
        [Key]
        [Column(TypeName = "VARCHAR2(255)")]
        public string IdIot { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public TipoIot TipoIot { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public string LatitudeIot { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public string LongitudeIot { get; set; }
        [Column(TypeName = "NUMBER")]
        public double UltimaLeituraIot { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public UnidadeMedidaIot UnidadeMedidaIot { get; set; }
        [Column(TypeName = "VARCHAR2(255)")]
        public StatusIot StatusIot { get; set; }

        public virtual ICollection<EventoEntity> Eventos { get; set; }
    }
}
